using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EatIfOver : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Enemy" && !Input.GetMouseButton(0)) {
            audioSource.Play();
            Destroy(other.gameObject);
        }
    }
}
