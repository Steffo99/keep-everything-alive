using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
public class EatIfOver : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite mouthOpenSprite;
    public Sprite satisfiedSprite;
    
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private MicrogameController microgameController;
    private bool eaten;

    void Awake() {
        microgameController = GameObject.FindGameObjectWithTag("MicrogameController").GetComponent<MicrogameController>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() {
        eaten = false;
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Enemy") {
            if(Input.GetMouseButton(0)) {
                spriteRenderer.sprite = mouthOpenSprite;
            }
            else {
                spriteRenderer.sprite = satisfiedSprite;
                audioSource.Play();
                eaten = true;
                microgameController.victory = true;
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(!eaten) {
            spriteRenderer.sprite = defaultSprite;
        }
    }
}
