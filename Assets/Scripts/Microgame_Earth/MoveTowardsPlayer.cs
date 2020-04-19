using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveTowardsPlayer : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float torqueMultiplier = 30f;

    private new Rigidbody2D rigidbody2D;
    private GameObject player;

    void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start() {
        rigidbody2D.AddForce((player.transform.position - transform.position).normalized * Random.value * forceMultiplier);
        rigidbody2D.AddTorque((Random.value - 0.5f) * 2f * torqueMultiplier);
    }
}
