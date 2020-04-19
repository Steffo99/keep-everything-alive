using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveRandomly : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float torqueMultiplier = 30f;

    private new Rigidbody2D rigidbody2D;

    void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start() {
        rigidbody2D.AddForce(new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0).normalized * Random.value * forceMultiplier);
        rigidbody2D.AddTorque((Random.value - 0.5f) * 2f * torqueMultiplier);
    }
}
