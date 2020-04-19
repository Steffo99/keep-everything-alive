using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum DisplayOnGameOverOptions {
    ALWAYS,
    SHOW_ON_GAME_OVER,
    HIDE_ON_GAME_OVER,
    NEVER
}


public class DisplayOnGameOver : MonoBehaviour
{
    public DisplayOnGameOverOptions displayWhen;

    private GameController gameController;
    private Text text;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        text = GetComponent<Text>();
    }

    private void Start() {
        gameController.OnGameOver += OnGameOver;
        gameObject.SetActive(displayWhen == DisplayOnGameOverOptions.ALWAYS || displayWhen == DisplayOnGameOverOptions.HIDE_ON_GAME_OVER);
    }

    private void OnGameOver(GameController sender) {
        gameObject.SetActive(displayWhen == DisplayOnGameOverOptions.ALWAYS || displayWhen == DisplayOnGameOverOptions.SHOW_ON_GAME_OVER);
    }
}
