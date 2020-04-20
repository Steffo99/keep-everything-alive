using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInArea : MonoBehaviour
{
    public GameObject instantiate;
    public Vector2 min;
    public Vector2 max;
    public int quantity = 1;

    private void Start()
    {
        for(int i = 0; i < quantity; i++) {
            Instantiate(instantiate, new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)), Quaternion.identity, transform);
        }
    }

}
