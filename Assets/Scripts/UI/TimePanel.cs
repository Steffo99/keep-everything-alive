using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePanel : MonoBehaviour
{
    private GameController gameController;

    [Header("References")]
    [BeforeStart]
    public RawImage empty;
    [BeforeStart]
    public RawImage full;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Start() {
        gameController.OnMicrogameTimeLeftChange += OnMicrogameTimeLeftChange;
    }

    private void OnMicrogameTimeLeftChange(float? previous, float? current) {
        if(current.HasValue) {
            empty.enabled = true;
            full.enabled = true;

            Rect emptyRect = empty.rectTransform.rect;
            full.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, emptyRect.x * gameController.CurrentMicrogame.TimeFraction);
        }
        else {
            empty.enabled = false;
            full.enabled = false;
        }
    }
}
