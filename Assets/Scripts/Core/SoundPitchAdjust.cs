using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundPitchAdjust : MonoBehaviour
{
    private GameController gameController;
    private AudioSource audioSource;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    private void Start() {
        gameController.OnSpeedChange += OnSpeedChange;
    }

    private void OnSpeedChange(float previous, float current) {
        audioSource.pitch = current;
    }
}
