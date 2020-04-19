using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundShuffle : MonoBehaviour
{
    public List<Sprite> backgrounds;
    
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() {
        spriteRenderer.sprite = backgrounds.PickRandom();
    }
}
