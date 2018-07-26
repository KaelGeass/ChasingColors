using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fluxo : MonoBehaviour {
	public void CarregarFase(){
		SceneManager.LoadScene ("Main");
	}
	public void MostrarControles(){
		SceneManager.LoadScene ("Controle");
	}
	public void FecharJogo(){
		Application.Quit ();
	}
}
