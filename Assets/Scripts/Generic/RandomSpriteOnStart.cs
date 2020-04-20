using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomSpriteOnStart : MonoBehaviour
{
    public List<Sprite> sprites;
    
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() {
        spriteRenderer.sprite = sprites.PickRandom();
    }
}
