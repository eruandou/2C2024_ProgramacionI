using UnityEngine;

namespace DefaultNamespace
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        private float health;

        private void Awake()
        {
            health = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}