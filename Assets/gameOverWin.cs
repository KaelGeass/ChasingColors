using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameOverWin : MonoBehaviour {

	// Use this for initialization
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			SceneManager.LoadScene ("Win");
		}
	}
		
}
