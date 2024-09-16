using System;
using UnityEngine;

namespace DefaultNamespace.Physics
{
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private float timer;

        [SerializeField] private Rigidbody rb;

        [SerializeField] private float explosionForce;
        [SerializeField] private float explosionRadius;
        [SerializeField] private float upwardsModifier;
        [SerializeField] private LayerMask collisionLayer;

        [SerializeField] private Mesh mesh;

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Explode();
                Destroy(gameObject);
            }
        }

        private void Explode()
        {
            Collider[] collisions =
                UnityEngine.Physics.OverlapSphere(transform.position, explosionRadius, collisionLayer);

            if (collisions.Length > 0) //Si son mas de 0, entonces hago el flujo de explosión
            {
                foreach (Collider collision in collisions)
                {
                    //Empujar a cada rigidbody
                    var collidedRigidbody = collision.GetComponent<Rigidbody>();
                    if (collidedRigidbody != null)
                    {
                        collidedRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius,
                            upwardsModifier, ForceMode.Impulse);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}