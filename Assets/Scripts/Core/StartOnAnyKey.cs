using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOnAnyKey : MonoBehaviour
{
    public float activateAfter = 1.5f;
    private bool active;

    void Start() {
        active = false;
        Invoke("Activate", activateAfter);
    }

    void Activate() {
        active = true;
    }

    void Update()
    {
        if(Input.anyKeyDown && active) {
            SceneManager.LoadScene("Default");
        }
    }
}
