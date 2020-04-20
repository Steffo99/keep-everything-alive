using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RequireCollisionMode {
    WIN_ON_COLLISION,
    LOSE_ON_COLLISION
}


public class RequireCollisionWithEnemy : MonoBehaviour
{
    public float activationDelay = 0.5f;
    public RequireCollisionMode mode = RequireCollisionMode.LOSE_ON_COLLISION;

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
            microgameController.victory = (mode == RequireCollisionMode.WIN_ON_COLLISION);
        }
    }
}
