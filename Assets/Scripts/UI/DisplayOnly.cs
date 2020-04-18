using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum DisplayOptions {
    ALWAYS,
    ONLY_DURING_MICROGAMES,
    ONLY_DURING_WHEEL,
    NEVER
}

public class DisplayOnly : MonoBehaviour
{
    public DisplayOptions displayWhen;

    private GameController gameController;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Start() {
        gameController.OnMicrogameCreate += OnMicrogameCreate;
        gameController.OnMicrogameDestroy += OnMicrogameDestroy;
        gameObject.SetActive(displayWhen == DisplayOptions.ALWAYS || displayWhen == DisplayOptions.ONLY_DURING_WHEEL);
    }

    private void OnMicrogameCreate(MicrogameController microgame) {
        gameObject.SetActive(displayWhen == DisplayOptions.ALWAYS || displayWhen == DisplayOptions.ONLY_DURING_MICROGAMES);
    }

    private void OnMicrogameDestroy(MicrogameController microgame) {
        gameObject.SetActive(displayWhen == DisplayOptions.ALWAYS || displayWhen == DisplayOptions.ONLY_DURING_WHEEL);
    }
}
