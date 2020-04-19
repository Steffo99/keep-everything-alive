using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailOnCollision : MonoBehaviour
{
    private MicrogameController microgameController;

    void Awake()
    {
        microgameController = GameObject.FindGameObjectWithTag("MicrogameController").GetComponent<MicrogameController>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            microgameController.victory = false;
        }
    }
}
