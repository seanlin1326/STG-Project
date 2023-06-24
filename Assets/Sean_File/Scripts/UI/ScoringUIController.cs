using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sean
{
    public class ScoringUIController : MonoBehaviour
    {
        [Header("=== Background ===")]
        [SerializeField] Image background;
        [SerializeField] Sprite[] backgroundImages;

        [Header("=== Scoring Screen ==")]
        [SerializeField] Canvas scoringScreenCanvas;
        [SerializeField] Text playerScoreText;
        [SerializeField] Button buttonMainMenu;
        private void Start()
        {
            ShowRandomBackground();
            ShowScoringScreen();
            ButtonPressedBehavior.buttonFunctionTable.Add(buttonMainMenu.gameObject.name, OnButtonMainMenuClicked);
            GameManager.CurrentGameState = GameState.Scoring;
        }
        private void OnDisable()
        {
            ButtonPressedBehavior.buttonFunctionTable.Clear();
        }
        private void ShowRandomBackground()
        {
            background.sprite = backgroundImages[Random.Range(0, backgroundImages.Length)];
        }

        private void ShowScoringScreen()
        {
            scoringScreenCanvas.enabled = true;
            playerScoreText.text = ScoreManager.Instance.Score.ToString();
            UIInput.Instance.SelectUI(buttonMainMenu);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            // Todo: Update high score leaderboard
        }

        private void OnButtonMainMenuClicked()
        {
            scoringScreenCanvas.enabled = false;
            SceneLoader.Instance.LoadMainMenuScene();
        }
    }
}