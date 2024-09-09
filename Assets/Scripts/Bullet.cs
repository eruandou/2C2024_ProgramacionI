using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float timeToDestroy;
        [SerializeField] private float damage;

        private void Awake()
        {
            Destroy(gameObject, timeToDestroy);
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

        private void OnCollisionEnter(Collision other)
        {
            var collidedGameObject = other.gameObject;
            //Necesito chequear la tag/label/etiqueta de el gameobject

            Enemy enemy = collidedGameObject.GetComponent<Enemy>();
            
            if (enemy != null) //Tiene el componente enemy
            {
                //Es un enemy
                Debug.Log("Collided with enemy");
                enemy.TakeDamage(damage);
            }
            else
            {
                //No es un enemy
                Debug.Log("Collided with something else");
            }

            Destroy(gameObject);
        }
    }
}