using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicrogamePanel : MonoBehaviour
{
    private GameController gameController;
    private Text text;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        text = GetComponent<Text>();
    }

    private void Start() {
        gameController.OnDisplayedMicrogameChange += OnDisplayedMicrogameChange;
    }

    private void OnDisplayedMicrogameChange(MicrogameController previous, MicrogameController current) {
        text.text = current.microgameName;
        text.color = current.microgameNameColor;
        text.font = current.microgameNameFont;
    }
}
