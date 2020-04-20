using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldExit : MonoBehaviour
{
    public KeyCode exitKey = KeyCode.Escape;
    public float holdTimeRequired = 1f;
    private float holdTime;

    void Start() {
        holdTime = 0f;
    }

    void Update()
    {
        if(Input.GetKey(exitKey)) {
            holdTime += Time.unscaledDeltaTime;
            if(holdTime >= holdTimeRequired) {
                Application.Quit(0);
            }
        }
        else {
            holdTime = 0f;
        }
    }
}
