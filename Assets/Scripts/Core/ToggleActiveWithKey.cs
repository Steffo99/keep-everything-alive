using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActiveWithKey : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.F2;
    public GameObject target;

    void Update() {
        if(Input.GetKeyDown(toggleKey)) {
            target.gameObject.SetActive(!target.gameObject.activeSelf);
        }
    }
}
