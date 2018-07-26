using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
   
    public class plataforma : MonoBehaviour {
		[SerializeField] private float m_JumpForce = 400f; 
        private PlatformerCharacter2D m_Character;
		public AudioSource Cogumelo;
		public AudioClip boing;
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Plataform")
            {
                transform.parent = collision.transform;
			}
            else if (collision.gameObject.tag == "Cogumelo")
            {
				m_Character.AddForce (new Vector2 (0f, m_JumpForce));
				Cogumelo.clip = boing;
				Cogumelo.Play ();
            }
            else transform.parent = null;
        }

		private void OnCollisionExit2D(Collision2D collision){
			transform.parent = null;
		}
    }
}