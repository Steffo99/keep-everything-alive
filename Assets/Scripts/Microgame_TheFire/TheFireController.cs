using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFireController : MonoBehaviour
{
    [Header("Microgame Config")]
    [BeforeStart]
    public int startingTreeHealth = 10;

    [Header("References")]
    public GameObject fireObject;
    public GameObject treeObject;
    public AudioSource chopAudioSource;
    public AudioSource fallAudioSource;
    private MicrogameController microgameController;
    private Animator fireAnimator;
    private Animator treeAnimator;

    [Header("Microgame State")]
    private int treeHealth;
    public int TreeHealth {
        get {
            return treeHealth;
        }
        set {
            treeAnimator.SetFloat("HealthFraction", (float)treeHealth / (float)startingTreeHealth);
            treeHealth = value;
            if(treeHealth == 0) {
                fallAudioSource.Play();
                microgameController.victory = true;
            }
            else if(treeHealth > 0) {
                chopAudioSource.Play();
                microgameController.victory = false;
            }
        }
    }

    private void Awake() {
        microgameController = GameObject.FindGameObjectWithTag("MicrogameController").GetComponent<MicrogameController>();
    }

    private void Start() {
        fireAnimator = fireObject.GetComponent<Animator>();
        treeAnimator = treeObject.GetComponent<Animator>();
        treeHealth = startingTreeHealth;
        microgameController.victory = false;
    }

    private void Update() {
        if(treeHealth > 0) {
            fireAnimator.SetFloat("TimeFraction", microgameController.TimeFraction);
        }
        else {
            fireAnimator.SetFloat("TimeFraction", 1);
        }
        DetectClicks();
    }

    private void DetectClicks() {
        if(Input.GetMouseButtonDown(0)) {
            Collider2D clicked = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if(clicked != null && clicked.gameObject == treeObject) {
                TreeHealth -= 1;
            }
        }
    }
}
