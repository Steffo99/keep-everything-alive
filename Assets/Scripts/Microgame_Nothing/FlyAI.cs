using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlyAI : MonoBehaviour
{
    public float speed;
    public Rect bounds;

    private Vector2 direction;
    private SpriteRenderer spriteRenderer;

    private bool flippedX;
    private bool flippedY;

    public static Vector2[] directions = new Vector2[4] {
        (Vector2.left + Vector2.up).normalized,
        (Vector2.left + Vector2.down).normalized,
        (Vector2.right + Vector2.up).normalized,
        (Vector2.right + Vector2.down).normalized
    };

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() {
        direction = directions.PickRandom();
        flippedX = false;
        flippedY = false;
    }

    void Update()
    {
        if(!flippedX && (transform.position.x < bounds.xMin || transform.position.x > bounds.xMax)) {
            direction = new Vector2(-direction.x, direction.y);
            flippedX = true;
        }
        else {
            flippedX = false;
        }
        if(!flippedY && (transform.position.y < bounds.yMin || transform.position.y > bounds.yMax)) {
            direction = new Vector2(direction.x, -direction.y);
            flippedY = true;
        }
        else {
            flippedY = false;
        }
        transform.Translate(speed * Time.deltaTime * direction);
        spriteRenderer.flipX = (direction.x > 0);
    }
}
