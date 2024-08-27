using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float timeToDestroy;

        private void Awake()
        {
            Destroy(gameObject, timeToDestroy);
        }

        private void Move()
        {
            transform.position += bulletSpeed * transform.forward;
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