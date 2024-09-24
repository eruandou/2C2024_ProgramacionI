using UnityEngine;

namespace DefaultNamespace
{
    public class MainCharacter : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private Bullet bullet;
        [SerializeField] private float shootingCooldownBase;
        [SerializeField] private PermanentBullet permanentBullet;
        [SerializeField] private float maxHealth;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float jumpForce;
        [SerializeField] private Transform raycastOrigin;
        [SerializeField] private float jumpCheckDistance;
        [SerializeField] private LayerMask groundLayer;

        [SerializeField] private Vector3 startingRotation;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip shootingSound;

        private EnemyBehaviour targetEnemy;
        private float health;

        private float shootingCooldown;

        private void Awake()
        {
            shootingCooldown = shootingCooldownBase;
            health = maxHealth;
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

            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            // Instantiate(permanentBullet, transform.position, transform.rotation);
            // }

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            movementDir = movementDir.normalized;
            Move(movementDir);
        }

        private void Jump()
        {
            //No puede saltar si el piso esta muy lejos

            bool hitGround =
                UnityEngine.Physics.Raycast(raycastOrigin.position, Vector3.down, jumpCheckDistance, groundLayer);

            if (!hitGround)
            {
                Vector3 direction = Vector3.up; //Lo mismo que escribir new Vector3(0,1,0)
                rb.AddForce(direction * jumpForce, ForceMode.Impulse);
                PlayJumpSound();
            }
        }

        private void Shoot()
        {
            //Disparo 
            Bullet instantiatedBullet = Instantiate(bullet, transform.position, transform.rotation);
            if (targetEnemy != null)
            {
                Vector3 direction = (targetEnemy.transform.position - transform.position).normalized;
                instantiatedBullet.transform.forward = direction;
            }

            PlayShootSound();
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

        public void Heal(float healAmount)
        {
            health += healAmount;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + Vector3.down * jumpCheckDistance);
        }

        private void PlayJumpSound()
        {
        }

        private void PlayShootSound()
        {
            audioSource.PlayOneShot(shootingSound);
        }
    }
}