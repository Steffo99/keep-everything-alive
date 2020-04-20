using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothingController : MonoBehaviour
{
    [Header("Microgame Config")]
    public int requiredDestructions = 3;

    [Header("References")]
    private MicrogameController microgameController;

    [Header("Microgame State")]
    private int currentDestructions;

    private void Awake() {
        microgameController = GameObject.FindGameObjectWithTag("MicrogameController").GetComponent<MicrogameController>();
    }

    private void Start() {
        microgameController.victory = false;
    }

    private void Update() {
        DetectClicks();
    }

    private void DetectClicks() {
        if(Input.GetMouseButtonDown(0)) {
            Collider2D clicked = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if(clicked != null) {
                Destructible d = clicked.GetComponent<Destructible>();
                if(!d.Destroyed) {
                    d.Destroyed = true;
                    currentDestructions += 1;
                    if(currentDestructions >= requiredDestructions) {
                        microgameController.victory = true;
                    }
                }
            }
        }
    }
}
