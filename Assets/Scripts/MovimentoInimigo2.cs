using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{

    [RequireComponent(typeof(PlatformerCharacter2D))]

    public class MovimentoInimigo2 : MonoBehaviour
    {
        private float tempoDeTrajetoX;
        private float tempoDeTrajetoY;
        public float tempoDeTrajetoMaxX;
        public float tempoDeTrajetoMaxY;
        public Vector2 velocity;
        private Rigidbody2D inimigo;
        void Start()
        {
            inimigo = GetComponent<Rigidbody2D>();
        }
        void FixedUpdate()
        {
            if (tempoDeTrajetoX <= tempoDeTrajetoMaxX)
            {
                inimigo.MovePosition(inimigo.position + velocity * Time.fixedDeltaTime);
            }
            else
            {
                tempoDeTrajetoX = 0;
                velocity.x = -velocity.x;
            }
            
            if (tempoDeTrajetoY <= tempoDeTrajetoMaxY)
            {
                if(velocity.y<0)
                    inimigo.MovePosition(inimigo.position + velocity * 3 * Time.fixedDeltaTime);
                else
                    inimigo.MovePosition(inimigo.position + velocity * Time.fixedDeltaTime);
            }
            else
            {
                tempoDeTrajetoY = 0;
                velocity.y = -velocity.y;
            }
            tempoDeTrajetoX = tempoDeTrajetoX + Time.deltaTime*1;
            tempoDeTrajetoY = tempoDeTrajetoY + Time.deltaTime * 1;
        }

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.tag == "Player") {
				other.gameObject.GetComponent<PlatformerCharacter2D> ().morre ();
			}
		}
	}
}