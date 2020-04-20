using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    private GameController gameController;
    private Text text;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        text = GetComponentInChildren<Text>();
    }

    private void Start() {
        gameController.OnScoreChange += OnScoreChange;
    }

    private void OnScoreChange(int previous, int current) {
        text.text = current.ToString();
    }

    private void OnEnable() {
        text.text = gameController.Score.ToString();
    }
}
