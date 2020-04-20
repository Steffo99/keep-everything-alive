using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnClick : MonoBehaviour
{
    public GameObject spawnablePrefab;
    public int startingQuantity;
    private int quantityLeft;

    void Start() {
        quantityLeft = startingQuantity;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && quantityLeft > 0) {
            Instantiate(spawnablePrefab, transform);
            quantityLeft -= 1;
        }
    }
}
