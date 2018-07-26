using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{

    [RequireComponent(typeof(PlatformerCharacter2D))]

    public class movimento_inimigo2 : MonoBehaviour
    {
        private float tempoDeTrajeto;
        public float tempoDeTrajetoMax;
        public Vector2 velocity;
        private Rigidbody2D inimigo;
        void Start()
        {
            inimigo = GetComponent<Rigidbody2D>();
        }
        void FixedUpdate()
        {
            if (tempoDeTrajeto <= tempoDeTrajetoMax)
            {
                inimigo.MovePosition(inimigo.position + velocity * Time.fixedDeltaTime);
            }
            else
            {
                tempoDeTrajeto = 0;
                velocity = -velocity;
            }

            tempoDeTrajeto = tempoDeTrajeto + Time.deltaTime * 1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlatformerCharacter2D>().morre();
            }
        }
    }
}