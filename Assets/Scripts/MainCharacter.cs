using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace DefaultNamespace
{
    public class MainCharacter : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private Bullet bullet;
        [SerializeField] private float shootingCooldownBase;

        private float shootingCooldown;

        private void Awake()
        {
            shootingCooldown = shootingCooldownBase;
        }

        private void Update()
        {
            //Mover utilizando WASD 

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 movementDir = new Vector2(horizontal, vertical);

            // if (Input.GetKey(KeyCode.W))
            // {
            //     movementDir.y += 1;
            // }
            //
            // if (Input.GetKey(KeyCode.A))
            // {
            //     movementDir.x -= 1;
            // }
            //
            // if (Input.GetKey(KeyCode.S))
            // {
            //     movementDir.y -= 1;
            // }
            //
            // if (Input.GetKey(KeyCode.D))
            // {
            //     movementDir.x += 1;
            // }

            //Si el jugador presiona Space Y el cooldown ya se termino, dispara

            shootingCooldown -= Time.deltaTime;
            if (Input.GetButton("Shoot") && shootingCooldown <= 0)
            {
                shootingCooldown = shootingCooldownBase;
                Shoot();
            }

            movementDir = movementDir.normalized;
            Move(movementDir);
        }

        private void Shoot()
        {
            //Disparo 
            Instantiate(bullet, transform.position, transform.rotation);
        }

        private void Move(Vector2 movementDir)
        {
            // Vector3 movement = new Vector3(movementDir.x, 0, movementDir.y);
            //Agarro el vector derecha del jugador y lo multiplico por x
            Vector3 right = transform.right * movementDir.x;
            //Agarro el vector adelante del jugador y lo multplico por y
            Vector3 forward = transform.forward * movementDir.y;
            //Sumo ambos vectores
            Vector3 direction = right + forward;

            transform.position += direction * movementSpeed * Time.deltaTime;
        }
    }
}