using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimePanel : MonoBehaviour
{
    private GameController gameController;
    private Slider slider;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        slider = GetComponentInChildren<Slider>();
    }

    private void Start() {
        gameController.OnMicrogameTimeLeftChange += OnMicrogameTimeLeftChange;
    }

    private void OnMicrogameTimeLeftChange(float? previous, float? current) {
        if(current.HasValue) {
            slider.value = gameController.CurrentMicrogame.TimeFraction;
        }
    }
}
