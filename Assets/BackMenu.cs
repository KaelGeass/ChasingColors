using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButtonDown ("Jump") || CrossPlatformInputManager.GetButtonDown ("Fire1")) 
		{
			SceneManager.LoadScene ("Menu");
		}
	}
}
