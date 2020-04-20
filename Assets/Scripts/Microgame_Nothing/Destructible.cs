using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class Destructible : MonoBehaviour {

    public Sprite normalSprite;
    public Sprite destroyedSprite;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private bool destroyed;
    public bool Destroyed {
        get {
            return destroyed;
        }
        set {
            destroyed = value;
            spriteRenderer.sprite = (value ? destroyedSprite : normalSprite);
            if(animator != null) {
                animator.enabled = !value;
            }
            if(value) {
                audioSource.Play();
            }
        }
    }

    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
}