using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MicrogameController : MonoBehaviour
{
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
        }
    }

    public float TimeFraction {
        get { 
            return startingTime / timeLeft;
        }
    }

    public abstract bool MicrogameResults();

    private void Update() {
        TimeLeft = Mathf.Clamp(TimeLeft - Time.deltaTime, 0, Mathf.Infinity);
    }
}
