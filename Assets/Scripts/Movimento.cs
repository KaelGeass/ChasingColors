using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (Transform))]
	
	public class Movimento : MonoBehaviour {
	
		private float x;
		// Use this for initialization
		void Start () {
			x=transform.position.x;
		}
		
		// Update is called once per frame
		void Update () {
	       // transform.position = new Vector3(transform.position.x+Mathf.PingPong(Time.time, 3), transform.position.y);
			 transform.position = new Vector3(x+Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);
	    }
	}
}
