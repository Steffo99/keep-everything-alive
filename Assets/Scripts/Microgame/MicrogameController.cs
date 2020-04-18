using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MicrogameController : MonoBehaviour
{
    [BeforeStart]
    public string microgameName = "[UNSET]";
    [BeforeStart]
    public float startingTime = 4f;

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
    public delegate void OnMicrogameEndHandler(MicrogameController microgame);
    public event OnMicrogameEndHandler OnMicrogameEnd;

    public abstract bool MicrogameResults();

    private void Start() {
        timeLeft = startingTime;
        OnMicrogameStart?.Invoke(this);
    }

    private void End() {
        OnMicrogameEnd?.Invoke(this);
    }

    private void Update() {
        TimeLeft -= Time.deltaTime;
    }
}
