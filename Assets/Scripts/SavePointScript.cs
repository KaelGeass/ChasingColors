using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class SavePointScript : MonoBehaviour {
		// Use this for initialization
		[SerializeField] private bool jaPassado = false;
		private void OnTriggerEnter2D(Collider2D other){
			if (other.tag == "Player" && !jaPassado) {
				GetComponent<AudioSource>().Play();
				other.gameObject.GetComponent<PlatformerCharacter2D> ().setSavePoint (this.transform);
				jaPassado = true;
			}
		}
	}
}