using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoBalinha : MonoBehaviour
{
    public AudioClip explosion;
    public AudioSource audioSource;
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        audioSource.PlayOneShot(explosion);
        if (col.gameObject.tag == "Inimigo")
        {

            Destroy(col.gameObject);
            
        }
        Destroy(gameObject);
    }
}