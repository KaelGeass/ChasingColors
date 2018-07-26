using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDinâmica : MonoBehaviour {
	public float tempoDeTrajetoMaximo;
	private float tempoDeTrajeto;
	private int direction = 1;
	public float velocidadeX = 1, velocidadeY = 0;
	private Vector3 V;


	void Start() {
		V =  new Vector3(velocidadeX, velocidadeY, 0);
	}

	void FixedUpdate() {
		if (tempoDeTrajeto <= tempoDeTrajetoMaximo) {
			transform.Translate (transform.position + V * Time.deltaTime * direction, Space.World);
		} 
		else {
			tempoDeTrajeto = 0;
			direction = direction * (-1);
		}
		tempoDeTrajeto = tempoDeTrajeto + Time.deltaTime;
	}
}
