using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class DragNDrop : MonoBehaviour
{
    public Vector2 min;
    public Vector2 max;

    private bool pickedUp;

    private new Rigidbody2D rigidbody2D;
    private new Collider2D collider2D;

    void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    void Start() {
        pickedUp = false;
    }

    void FixedUpdate()
    {
        if(pickedUp) {
            Vector3 screenPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Mathf.Clamp(screenPoint.x, min.x, max.x), Mathf.Clamp(screenPoint.y, min.y, max.y), transform.position.z);
        }
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Collider2D clicked = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if(clicked == collider2D) {
                pickedUp = true;
            }
        }
        else if(Input.GetMouseButtonUp(0)) {
            pickedUp = false;
        }
    }
}
