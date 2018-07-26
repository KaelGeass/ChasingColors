using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{

	[RequireComponent(typeof (PlatformerCharacter2D))]
    [RequireComponent(typeof(ParticleScript))]

    public class LightCollider : MonoBehaviour {
		public AudioSource source;
		public AudioClip powerup;
		private PlatformerCharacter2D m_Character;

		private void Awake(){
			m_Character = GetComponent<PlatformerCharacter2D>();
		}

        private void OnTriggerEnter2D(Collider2D collision){
            ParticleScript ps = (ParticleScript)collision.gameObject.GetComponent("ParticleScript");
            if (ps != null){
				source.volume = 0.6f;
				source.clip = powerup;
				source.Play ();
                ps.liberaPoderzinho(m_Character);
                Destroy(collision.gameObject);
                
            }
        }

    }

}


