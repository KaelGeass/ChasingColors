using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMov : MonoBehaviour {
	
	private float tempoDeTrajeto;
	public float velocidadeX,velocidadeY,tempoDeTrajetoMax;
	
	// Update is called once per frame
	void FixedUpdate () {
		if (tempoDeTrajeto <= tempoDeTrajetoMax) {
			transform.position += new Vector3 (velocidadeX * Time.deltaTime, velocidadeY * Time.deltaTime, 0);
		} 
		else {
			tempoDeTrajeto = 0;
			velocidadeX = -velocidadeX;
			velocidadeY = -velocidadeY;
		}

		tempoDeTrajeto = tempoDeTrajeto + Time.deltaTime*1;
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.transform.parent = transform;
		}
		else collision.transform.parent = null;
	}
}
