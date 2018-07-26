using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{

    [RequireComponent(typeof(PlatformerCharacter2D))]

    public class MovimentoInimigo3 : MonoBehaviour
    {
        private float tempoDeTrajeto;
        public float tempoDeTrajetoMax;
        public Vector2 velocity;
        private Rigidbody2D inimigo;
        private Vector2 newPosition;
        void Start()
        {
            inimigo = GetComponent<Rigidbody2D>();
        }
        void FixedUpdate()
        {
            if (tempoDeTrajeto<tempoDeTrajetoMax/4)
            {
                newPosition = new Vector2(inimigo.position.x + velocity.x * Time.fixedDeltaTime, inimigo.position.y);
                inimigo.MovePosition(newPosition);
            }
            else if(tempoDeTrajeto >= tempoDeTrajetoMax/4 && tempoDeTrajeto < (2*tempoDeTrajetoMax)/4)
            {
                newPosition = new Vector2(inimigo.position.x + velocity.x * Time.fixedDeltaTime, inimigo.position.y - velocity.y * Time.fixedDeltaTime);
                inimigo.MovePosition(newPosition);
            }
            else if (tempoDeTrajeto >= (2*tempoDeTrajetoMax)/4 && tempoDeTrajeto < (3*tempoDeTrajetoMax)/4)
            {
                newPosition = new Vector2(inimigo.position.x + velocity.x * Time.fixedDeltaTime, inimigo.position.y + velocity.y * Time.fixedDeltaTime);
                inimigo.MovePosition(newPosition);
            }
            else if (tempoDeTrajeto >= (3*tempoDeTrajetoMax)/4 && tempoDeTrajeto<= tempoDeTrajetoMax)
            {
                newPosition = new Vector2(inimigo.position.x + velocity.x * Time.fixedDeltaTime, inimigo.position.y);
                inimigo.MovePosition(newPosition);
            }
            else
            {
                velocity.x = -velocity.x;
                tempoDeTrajeto = 0;
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