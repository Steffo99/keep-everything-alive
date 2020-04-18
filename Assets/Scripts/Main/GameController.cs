using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public new Camera camera;

    [BeforeStart]
    public int startingLives = 4;
    [BeforeStart]
    public int maxLives = 4;
    private int lives;
    public delegate void OnLivesChangeHandler(int previous, int current);
    public event OnLivesChangeHandler OnLivesChange;
    public delegate void OnGameOverHandler(GameController sender);
    public event OnGameOverHandler OnGameOver;
    public int Lives {
        get {
            return lives;
        }
        set {
            OnLivesChange?.Invoke(Lives, value);
            lives = value;
            if(lives <= 0) {
                OnGameOver?.Invoke(this);
            }
        }
    }

    [BeforeStart]
    public float startingTimescale = 1.0f;
    public delegate void OnSpeedChangeHandler(float previous, float current);
    public event OnSpeedChangeHandler OnSpeedChange;
    public float Timescale {
        get {
            return Time.timeScale;
        }
        set {
            OnSpeedChange?.Invoke(Timescale, value);
            Time.timeScale = value;
        }
    }

    [BeforeStart]
    public int startingDifficulty = 1;
    private int difficulty;
    public delegate void OnDifficultyChangeHandler(int previous, int current);
    public event OnDifficultyChangeHandler OnDifficultyChange;
    public int Difficulty {
        get {
            return difficulty;
        }
        set {
            OnDifficultyChange?.Invoke(Difficulty, value);
            difficulty = value;
        }
    }

    [BeforeStart]
    public int startingScore = 0;
    private int score;
    public delegate void OnScoreChangeHandler(int previous, int current);
    public event OnScoreChangeHandler OnScoreChange;
    public int Score {
        get {
            return score;
        }
        set {
            OnScoreChange?.Invoke(Score, value);
            score = value;
        }
    }

    public List<MicrogameController> microgames;
    private MicrogameController currentMicrogame;
    public delegate void OnMicrogameStartHandler(MicrogameController newMicrogame);
    public event OnMicrogameStartHandler OnMicrogameStart;
    public delegate void OnMicrogameEndHandler(MicrogameController endedMicrogame);
    public event OnMicrogameEndHandler OnMicrogameEnd;
    public MicrogameController CurrentMicrogame {
        get {
            return currentMicrogame;
        }
        set {
            if(value == null) {
                OnMicrogameEnd?.Invoke(CurrentMicrogame);
                OnMicrogameTimeLeftChange?.Invoke(CurrentMicrogame.TimeLeft, null);
                CurrentMicrogame.OnTimeLeftChange -= PropagateTimeLeftChange;
                Destroy(CurrentMicrogame.gameObject);
            }
            else {
                currentMicrogame = Instantiate(value.gameObject, transform).GetComponent<MicrogameController>();
                OnMicrogameTimeLeftChange?.Invoke(null, CurrentMicrogame.TimeLeft);
                CurrentMicrogame.OnTimeLeftChange += PropagateTimeLeftChange;
                OnMicrogameStart?.Invoke(CurrentMicrogame);
            }
        }
    }

    public delegate void OnMicrogameTimeLeftChangeHandler(float? previous, float? current);
    public event OnMicrogameTimeLeftChangeHandler OnMicrogameTimeLeftChange;
    private void PropagateTimeLeftChange(float previous, float current) {
        OnMicrogameTimeLeftChange?.Invoke(previous, current);
    }

    private void Awake() {
        camera = Camera.main;
    }

    private void Start() {
        Lives = 4;
        Timescale = 1.0f;
        Difficulty = 1;
        currentMicrogame = null;
    }

    private void CheckMicrogameResults(MicrogameController microgame) {
        Debug.Assert(microgame != null);
        if(microgame.MicrogameResults()) {
            Score += 1;
        }
        else {
            Lives -= 1;
        }
    }

    private MicrogameController GetRandomMicrogame() {
        return microgames.PickRandom();
    }
}
