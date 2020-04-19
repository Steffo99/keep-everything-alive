using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextOnGameOver : MonoBehaviour
{
    public string displayText;
    public Color displayColor;

    private GameController gameController;
    private Text text;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        text = GetComponent<Text>();
    }

    private void Start() {
        gameController.OnGameOver += OnGameOver;
    }

    private void OnGameOver(GameController sender) {
        text.text = displayText;
        text.color = displayColor;
    }
}
