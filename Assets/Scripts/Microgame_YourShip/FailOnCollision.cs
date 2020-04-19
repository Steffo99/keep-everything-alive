using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailOnCollision : MonoBehaviour
{
    public float activationDelay = 0.5f;

    private MicrogameController microgameController;
    private bool active;

    void Awake()
    {
        microgameController = GameObject.FindGameObjectWithTag("MicrogameController").GetComponent<MicrogameController>();
        Invoke("Activate", activationDelay);
    }

    void Activate() {
        active = true;
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Enemy" && active) {
            microgameController.victory = false;
        }
    }
}
