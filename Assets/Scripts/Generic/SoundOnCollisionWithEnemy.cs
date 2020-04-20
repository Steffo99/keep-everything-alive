using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundOnCollisionWithEnemy : MonoBehaviour
{
    public float activationDelay = 0.5f;

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

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Enemy" && active) {
            audioSource.Play();
            active = false;
        }
    }
}
