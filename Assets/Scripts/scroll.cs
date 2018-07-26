using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {

	public float speed  = 0.5f;

	void Start() {

	}

	void Update() {
		Vector2 offset = new Vector2 (Time.time * speed, 0);
		/* COMENTARIO DO YOUTUBE RELEVANTE
		  if your updated tot he newest version of unity 5.1 something. for it to work you will have to change 
		  renderer.material.mainTextureOffset = offset; 
		  to 
		  GetComponent<Renderer>().material.mainTextureOffset = offset;﻿ USAR ESSE PROVAVELMENTE 
		*/

		// renderer. material.mainTextureOffset = offset;// JA TROQUEI

		GetComponent<Renderer>().material.mainTextureOffset = offset;﻿

	}
}