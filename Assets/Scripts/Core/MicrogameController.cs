using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameController : MonoBehaviour
{
    [Header("Microgame Settings")]
    [BeforeStart]
    public float startingTime = 4f;

    [Header("Wheel Settings")]
    [BeforeStart]
    public string microgameName;
    [BeforeStart]
    public Color microgameNameColor;
    [BeforeStart]
    public Font microgameNameFont;

    [Header("Microgame Results")]
    public bool victory = true;

    protected GameController gameController;

    public delegate void OnTimeLeftChangeHandler(float previous, float current);
    public event OnTimeLeftChangeHandler OnTimeLeftChange;
    private float timeLeft;
    public float TimeLeft {
        get {
            return timeLeft;
        }
        set {
            OnTimeLeftChange?.Invoke(TimeLeft, value);
            timeLeft = value;
            if(timeLeft <= 0) {
                End();
            }
        }
    }
    public float TimeFraction {
        get { 
            return timeLeft / startingTime;
        }
    }

    public delegate void OnMicrogameStartHandler(MicrogameController microgame);
    public event OnMicrogameStartHandler OnMicrogameStart;
    public delegate void OnMicrogameEndHandler(MicrogameController microgame, bool victory);
    public event OnMicrogameEndHandler OnMicrogameEnd;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Start() {
        timeLeft = startingTime;
        OnMicrogameStart?.Invoke(this);
    }

    private void End() {
        OnMicrogameEnd?.Invoke(this, victory);
    }

    private void Update() {
        TimeLeft -= Time.deltaTime;
    }
}
