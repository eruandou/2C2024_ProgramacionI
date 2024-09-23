using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyState
    {
        public EnemyStates currentState;
    }

    public enum EnemyStates
    {
        Confused = 0,
        Fleeing = 1,
        Pursuit = 2,
        Stay = 3,
        Dead = 4,
        LookAtPlayer = 5
    }

    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private float lowHealthThreshold = 5;
        [SerializeField] private EnemyStates startingState;
        [SerializeField] private MainCharacter player;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float pursuitThreshold;
        [SerializeField] private float rotationSpeed;

        private void Update()
        {
            CheckStateUpdate();
            switch (startingState)
            {
                case EnemyStates.Confused:
                    RandomMovement();
                    break;
                case EnemyStates.Fleeing:
                    Flee();
                    break;
                case EnemyStates.Pursuit:
                    Pursuit();
                    break;
                case EnemyStates.Stay:
                    Stay();
                    break;

                case EnemyStates.LookAtPlayer:
                    LookRotationQuaternion();
                    break;
                case EnemyStates.Dead:
                default:
                    Stay();
                    break;
            }
        }

        private void LookAtPlayer()
        {
            transform.LookAt(player.transform);
        }

        private void LookRotationQuaternion()
        {
            var newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
        }

        private void CheckStateUpdate()
        {
            //Si el player esta muy lejos, me quedo quieto
            var diff = transform.position - player.transform.position;
            var distance = diff.magnitude;

            if (distance > pursuitThreshold)
            {
                if (startingState == EnemyStates.Pursuit)
                {
                    startingState = EnemyStates.Stay;
                }
            }
            else
            {
                startingState = EnemyStates.Pursuit;
            }
        }

        private void Stay()
        {
            Debug.Log("Stay");
        }

        private void Pursuit()
        {
            Debug.Log("Pursuit");
            //A - B => A es el objetivo (player) y B es el interesado (enemigo)
            Vector3 a = player.transform.position;
            Vector3 b = transform.position;
            Vector3 diff = (a - b).normalized;
            transform.position += diff * (Time.deltaTime * movementSpeed);
        }

        private void Flee()
        {
            Debug.Log("Flee");
            Vector3 a = player.transform.position;
            Vector3 b = transform.position;
            Vector3 diff = (b - a).normalized;
            transform.position += diff * (Time.deltaTime * movementSpeed);
        }

        private void RandomMovement()
        {
            Debug.Log("Random Movement");
        }
    }
}