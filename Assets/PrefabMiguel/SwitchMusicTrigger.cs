using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour {

	public AudioClip newTrack;
	private SoundManager theAM;

	// Use this for initialization
	void Start () {
		theAM = FindObjectOfType<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col){
		print ("Musica mudou");
		if (col.tag == "Player") {
			if(newTrack != null)
				theAM.changeMusic (newTrack);
		}
	}

}