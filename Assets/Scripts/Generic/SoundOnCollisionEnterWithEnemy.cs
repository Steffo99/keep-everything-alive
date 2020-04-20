using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SoundOnCollisionEnterWithEnemy : MonoBehaviour
{
    public float activationDelay = 0.5f;

    public string targetTag = "Enemy";

    private AudioSource audioSource;
    private bool active;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("Activate", activationDelay);
    }
    
    void Activate() {
        active = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == targetTag && active) {
            audioSource.Play();
        }
    }
}
