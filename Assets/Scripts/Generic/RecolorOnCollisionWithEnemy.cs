using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RecolorOnCollisionWithEnemy : MonoBehaviour
{
    public Color color;
    public float activationDelay = 0.5f;

    private SpriteRenderer spriteRenderer;
    private bool active;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Activate", activationDelay);
    }
    
    void Activate() {
        active = true;
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Enemy" && active) {
            spriteRenderer.color = color;
        }
    }
}
