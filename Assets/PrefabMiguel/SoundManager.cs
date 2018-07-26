using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource AudioAtual;

	public void changeMusic(AudioClip music){
		if (AudioAtual.clip.name == music.name) 
			return;

		AudioAtual.Stop ();
		AudioAtual.clip = music;
		AudioAtual.Play ();
	}
}
