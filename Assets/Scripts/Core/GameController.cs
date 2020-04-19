using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool GameOver {
        get {
            return Lives <= 0;
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
    public delegate void OnMicrogameCreateHandler(MicrogameController newMicrogame);
    public event OnMicrogameCreateHandler OnMicrogameCreate;
    public delegate void OnMicrogameDestroyHandler(MicrogameController endedMicrogame);
    public event OnMicrogameDestroyHandler OnMicrogameDestroy;
    public MicrogameController CurrentMicrogame {
        get {
            return currentMicrogame;
        }
        set {            
            if(CurrentMicrogame != null) {
                OnMicrogameDestroy?.Invoke(CurrentMicrogame);
                CurrentMicrogame.OnTimeLeftChange -= PropagateTimeLeftChange;
                CurrentMicrogame.OnMicrogameEnd -= OnMicrogameEnd;
                Destroy(CurrentMicrogame.gameObject);
            }
            if(value != null) {
                currentMicrogame = Instantiate(value.gameObject, transform).GetComponent<MicrogameController>();
                CurrentMicrogame.OnTimeLeftChange += PropagateTimeLeftChange;
                CurrentMicrogame.OnMicrogameEnd += OnMicrogameEnd;
                OnMicrogameCreate?.Invoke(CurrentMicrogame);
            }

            OnMicrogameTimeLeftChange?.Invoke(CurrentMicrogame?.TimeLeft, value?.TimeLeft);
        }
    }

    public delegate void OnMicrogameTimeLeftChangeHandler(float? previous, float? current);
    public event OnMicrogameTimeLeftChangeHandler OnMicrogameTimeLeftChange;
    private void PropagateTimeLeftChange(float previous, float current) {
        OnMicrogameTimeLeftChange?.Invoke(previous, current);
    }

    private void OnMicrogameEnd(MicrogameController microgame, bool victory) {
        Debug.Assert(microgame != null);
        if(!victory) {
            Lives -= 1;
        }
        Score += 1;
        CurrentMicrogame = null;
        if(!GameOver) {
            if(score % increaseSpeedEvery == 0) {
                Faster();
            }
            StartCoroutine("SpinTheWheel");
        }
    }

    public float timescaleIncreaseFactor = 0.05f;
    public float increaseSpeedEvery = 5;
    private void Faster() {
        Timescale += timescaleIncreaseFactor;
    }

    private MicrogameController displayedMicrogame;

    public delegate void OnDisplayedMicrogameChangeHandler(MicrogameController previous, MicrogameController current);
    public event OnDisplayedMicrogameChangeHandler OnDisplayedMicrogameChange;
    public MicrogameController DisplayedMicrogame {
        get {
            return displayedMicrogame;
        }
        set {
            OnDisplayedMicrogameChange?.Invoke(displayedMicrogame, value);
            displayedMicrogame = value;
        }
    }

    [Header("Wheel Settings")]
    public float wheelSelectionDelay = 0.1f;
    public float wheelSelectionTime = 2f;
    public float wheelDisplayTime = 2f;
    public AudioSource wheelClickAudioSource;
    public AudioSource wheelBoopAudioSource;

    IEnumerator SpinTheWheel() {
        float timePassed = 0f;
        while(timePassed < wheelSelectionTime) {
            DisplayedMicrogame = GetRandomMicrogame();
            wheelClickAudioSource.Play();
            yield return new WaitForSeconds(wheelSelectionDelay);
            timePassed += wheelSelectionDelay;
        }
        DisplayedMicrogame = GetRandomMicrogame();
        wheelBoopAudioSource.Play();
        yield return new WaitForSeconds(wheelDisplayTime);
        CurrentMicrogame = DisplayedMicrogame;
    }

    public MicrogameController GetRandomMicrogame() {
        Debug.Assert(microgames.Count > 0);
        return microgames.PickRandom();
    }  

    private void Awake() {
        camera = Camera.main;
    }

    private void Start() {
        Lives = startingLives;
        Timescale = startingTimescale;
        Score = startingScore;
        CurrentMicrogame = null;
        // Notify the TimePanel of the starting status
        OnMicrogameTimeLeftChange?.Invoke(null, null);

        StartCoroutine("SpinTheWheel");
    }

    private void Update() {
        if(GameOver) {
            if(Input.anyKeyDown) {
                SceneManager.LoadScene("Default");
            }
        }
    }
}
