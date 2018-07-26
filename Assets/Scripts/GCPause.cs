using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GCPause : MonoBehaviour {

	public GameObject menu;

	void Start () {
		menu.SetActive(false);
	}

	void Update() {
		if (Input.GetButtonDown("Cancel")) {
			menu.SetActive(true);
			Time.timeScale = 0f;
		}  
	}

	public void botaoVoltar() {
		Time.timeScale = 1f;
		menu.SetActive(false);
	}
		
	public void botaoMenuPrincipal() {
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
	}
}
