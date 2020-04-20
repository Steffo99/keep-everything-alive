using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StretchToFollowOptions {
    HORIZONTAL,
    VERTICAL
}

public class StretchToFollow : MonoBehaviour
{
    public GameObject target;
    public StretchToFollowOptions mode;

    private Vector3 startingTargetPosition;

    void Start() {
        startingTargetPosition = target.transform.position;
        transform.position = startingTargetPosition;
    }

    void Update() {
        if(mode == StretchToFollowOptions.HORIZONTAL) {
            transform.localScale = new Vector3(Mathf.Abs(target.transform.position.x - startingTargetPosition.x) * 2, transform.localScale.y, transform.localScale.z);
        }
        else {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(target.transform.position.y - startingTargetPosition.y) * 2, transform.localScale.z);
        }
    }
}
