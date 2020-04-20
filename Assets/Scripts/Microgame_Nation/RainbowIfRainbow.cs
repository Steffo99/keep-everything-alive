using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowIfRainbow : MonoBehaviour
{
    public SpriteRenderer planeObject;
    public Sprite rainbowPlane;

    void Start() {
        if(planeObject.sprite != rainbowPlane) {
            gameObject.SetActive(false);
        }
    }
}
