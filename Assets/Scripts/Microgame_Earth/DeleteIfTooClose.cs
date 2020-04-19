using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteIfTooClose : MonoBehaviour
{
    private GameObject player;
    public float threshold = 1f;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start() {
        if(Vector2.Distance(transform.position, player.transform.position) <= threshold) {
            Destroy(gameObject);
        }
    }
}
