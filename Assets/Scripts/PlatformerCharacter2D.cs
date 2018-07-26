using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(Poderzinho))]

    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 500f;                  // Amount of force added when the player jumps.
        private float m_runSpeed = 2.0f;  // Amount of maxSpeed applied to runing movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        public bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

        public Transform bulletSpawn;
        public GameObject bulletPrefab;

        public int velocidadeBalinha = 12;
        public float recargaDeBalinha = 1.0f;
        public bool recarga = true;
        public float timerBalinha;


//        [SerializeField] private int vidas = 3;
        [SerializeField] private Vector3 respawn;
        [SerializeField] private bool[] power; // vetor de poderzinhos se o poder estiver ativado mudar para true

		public AudioSource source;
		public AudioClip morrer;

        private void Awake()
        {

            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            power = new bool[Enum.GetNames(typeof(Poderzinho)).Length];
            for (int i = 0; i < Enum.GetNames(typeof(Poderzinho)).Length; i++)
            {
                power[i] = false;
            }
            respawn = this.transform.position;
        }


        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }

        public void Move(float move, bool run, bool jump, bool bala)
        {
			

			//only control the player if grounded or airControl is turned on
			if ((m_Grounded || m_AirControl) )
            {
				// Set whether or not the character is crouching in the animator
				m_Anim.SetBool("Run", run);
				// Reduce the speed if runing by the runSpeed multiplier
				move = ((run && power[(int)Poderzinho.correr]) ? move * m_runSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground") && power[(int)Poderzinho.pulo])
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                transform.parent = null;
            }


            if (bala && power[(int)Poderzinho.tiro] && timerBalinha >= recargaDeBalinha)
            {
                fire();
                timerBalinha = 0;
            }
        }

        public void setCan(Poderzinho b)
        {
            power[(int)b] = true;
        }

        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        public void AddForce(Vector2 v)
        {

            m_Rigidbody2D.AddForce(v);
        }

        public void fire()
        {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            // Add velocity to the bullet
            if (m_FacingRight)
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidadeBalinha;
            else
            {
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidadeBalinha;
                Vector3 theScale = bullet.GetComponent<Transform>().localScale;
                theScale.x *= -1;
                bullet.GetComponent<Transform>().localScale = theScale;
            }
            // Destroy the bullet after 2 seconds
            Destroy(bullet, 3.0f);
        }
        void Update()
        {
            //atualiza timer
            timerBalinha = timerBalinha + Time.deltaTime;
        }
        public void morre()
        {
//            if (vidas > 0)
//            {	
//                vidas--;
                this.transform.position = respawn;
//            }
//            else
//            {
//                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
//            }
			source.clip = morrer;
			source.Play ();
        }
        public void setSavePoint(Transform transf)
        {
            this.respawn = transf.position;
        }
    }
}