using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FollowMouseOptions {
    ALWAYS,
    ONLY_WHEN_HOLDING_LMB
}

[RequireComponent(typeof(Rigidbody2D))]
public class FollowMouse : MonoBehaviour
{
    public Vector2 min;
    public Vector2 max;
    public FollowMouseOptions options = FollowMouseOptions.ALWAYS;

    private new Rigidbody2D rigidbody2D;

    void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start() {
        if(options == FollowMouseOptions.ALWAYS) {
            Vector3 screenPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Mathf.Clamp(screenPoint.x, min.x, max.x), Mathf.Clamp(screenPoint.y, min.y, max.y), transform.position.z);
        }
    }

    void FixedUpdate()
    {
        if(options == FollowMouseOptions.ALWAYS) {
            Vector3 screenPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Mathf.Clamp(screenPoint.x, min.x, max.x), Mathf.Clamp(screenPoint.y, min.y, max.y), transform.position.z);
        }
    }
}
