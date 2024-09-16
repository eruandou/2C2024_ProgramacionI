using System;
using UnityEngine;

namespace DefaultNamespace.Physics
{
    public class TorquePusher : MonoBehaviour
    {
        [SerializeField] private float pushForce;
        [SerializeField] private Vector3 pushDirection;
        [SerializeField] private float initialTemp;
        [SerializeField] private Rigidbody rb;

        [SerializeField] private bool isTorque;

        private float currentTime;

        private void Awake()
        {
            currentTime = initialTemp;
        }

        private void Update()
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                ApplyTorque();
            }
        }

        private void ApplyTorque()
        {
            if (isTorque)
            {
                rb.AddTorque(pushForce * pushDirection, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }
}