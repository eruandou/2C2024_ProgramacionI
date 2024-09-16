using System;
using UnityEngine;

namespace DefaultNamespace.Obstacles
{
    public class HealArea : MonoBehaviour
    {
        [SerializeField] private float healAmount;
        
        private void OnTriggerStay(Collider other)
        {
            Heal(other.gameObject);
        }

        private void Heal(GameObject target)
        {
            MainCharacter mainCharacter = target.GetComponent<MainCharacter>();
            if (mainCharacter != null)
            {
                mainCharacter.Heal(healAmount * Time.fixedDeltaTime);
            }
        }
    }
}