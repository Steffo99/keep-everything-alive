using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesPanel : MonoBehaviour
{
    private GameController gameController;
    [BeforeStart]
    public Image lifeImagePrefab;
    [BeforeStart]
    public Sprite lifeFull;
    [BeforeStart]
    public Sprite lifeEmpty;
    [BeforeStart]
    public float livesImagesGap = 0f;

    private Image[] livesImages;

    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Start() {
        gameController.OnLivesChange += OnLivesChange;
        livesImages = new Image[gameController.maxLives];
        for(int i = 0; i < gameController.maxLives; i++) {
            Image created = Instantiate(lifeImagePrefab.gameObject, transform).GetComponent<Image>();
            livesImages[i] = created;
            created.name = "Life #" + i.ToString();
            created.rectTransform.anchoredPosition = new Vector2(-i * (created.rectTransform.rect.width + livesImagesGap), 0);
        }
    }

    private void OnLivesChange(int previous, int current) {
        for(int i = 0; i < livesImages.Length; i++) {
            if(i < current) {
                livesImages[i].sprite = lifeFull;
            }
            else {
                livesImages[i].sprite = lifeEmpty;
            }
        }
    }
}
