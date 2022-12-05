using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;

        private bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;

        private bool isGrounded;
        public Transform groundCheck;
        public AudioClip jump;
        public AudioClip coin;

        private Rigidbody2D rigidbody;
        private Animator animator;
        private GameManager gameManager;
        private AudioSource audioSource;

        private bool deadFirstTrigger = false;

        public LayerMask groundLayer;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            audioSource = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        void Update()
        {
            if (Input.GetButton("Horizontal")) 
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetInteger("playerState", 1); // Turn on run animation
            }
            else
            {
                if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
            }
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                audioSource.PlayOneShot(jump);
            }
            if (!isGrounded)animator.SetInteger("playerState", 2); // Turn on jump animation

            if(facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if(facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f, layerMask: groundLayer);
            isGrounded = colliders.Length >= 1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(other.collider.transform.name);
            if (other.collider.transform.tag == "Enemy")
            {
                deathState = true; // Say to GameManager that player is dead
            }
            else if (other.collider.transform.CompareTag("Kill")) {
                other.collider.gameObject.GetComponentInParent<EnemyAI>().Kill(audioSource);
                rigidbody.AddForce (new Vector2(- rigidbody.velocity.x, 1) * 5, ForceMode2D.Impulse);

            }
            else
            {
                deathState = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
                gameManager.coinsCounter += 1;
                Destroy(other.gameObject);
                audioSource.PlayOneShot(coin);
            }
        }
    }
}
