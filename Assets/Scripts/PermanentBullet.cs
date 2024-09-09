using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PermanentBullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float timeToDestroy;
        [SerializeField] private float damagePerTick;

        private void OnCollisionStay(Collision other)
        {
            var enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damagePerTick * Time.fixedDeltaTime);
            }
        }

        private void Move()
        {
            transform.position += speed * transform.forward * Time.deltaTime;
        }

        private void Update()
        {
            timeToDestroy -= Time.deltaTime;
            if (timeToDestroy <= 0)
            {
                Destroy(gameObject);
            }

            Move();
        }
    }
}