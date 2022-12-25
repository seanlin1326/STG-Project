using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sean
{
    public class GamePlayUIController : MonoBehaviour
    {
        [Header("=== Player Input ===")]
        [SerializeField] PlayerInput playerInput;
        [Header("=== Audio Data ===")]
        [SerializeField] AudioData pauseSFX;
        [SerializeField] AudioData unpauseSFX;
        [Header("=== Canvas ===")]
        [SerializeField] Canvas hudCanvas;
        [SerializeField] Canvas menusCanvas;
        [Header("=== Player Input ===")]
        [SerializeField] Button resumeButton;
        [SerializeField] Button optionsButton;
        [SerializeField] Button mainMenuButton;

        readonly private int buttonPressedParameterID = Animator.StringToHash("Pressed");
        private void OnEnable()
        {
            playerInput.onPause += Pause;
            playerInput.onUnpause += Unpause;

            ButtonPressedBehavior.buttonFunctionTable.Add(resumeButton.gameObject.name,OnResumeButtonClick);
            ButtonPressedBehavior.buttonFunctionTable.Add(optionsButton.gameObject.name,OnOptionsButtonClick);
            ButtonPressedBehavior.buttonFunctionTable.Add(mainMenuButton.gameObject.name, OnMainMenuButtonClick);
        }
        private void OnDisable()
        {
            playerInput.onPause -= Pause;
            playerInput.onUnpause -= Unpause;

            ButtonPressedBehavior.buttonFunctionTable.Clear();
        }
        private void Pause()
        {
            GameManager.CurrentGameState = GameState.Paused;
            TimeController.Instance.Pause();
            hudCanvas.enabled = false;
            menusCanvas.enabled = true;
            playerInput.EnablePauseMenuInput();
            playerInput.SwitchToDynamicUpdateMode();
            UIInput.Instance.SelectUI(resumeButton);
            AudioManager.Instance.PlaySFX(pauseSFX);
        }
        public void Unpause()
        {
            resumeButton.Select();
            resumeButton.animator.SetTrigger(buttonPressedParameterID);
            AudioManager.Instance.PlaySFX(unpauseSFX);
        }
       private void OnResumeButtonClick()
        {
            GameManager.CurrentGameState = GameState.Playing;
            TimeController.Instance.Unpause();
            hudCanvas.enabled = true;
            menusCanvas.enabled = false;
            playerInput.EnableGamePlayInput();
            playerInput.SwitchToFixedUpdateMode();
        }
       private void OnOptionsButtonClick()
        {
            //TODO
            UIInput.Instance.SelectUI(optionsButton);
            playerInput.EnablePauseMenuInput();
        }
       private void OnMainMenuButtonClick()
        {
            menusCanvas.enabled = false;
            GameManager.CurrentGameState = GameState.Playing;
            Time.timeScale = 1f;
            //Load Main Menu Scene
            SceneLoader.Instance.LoadMainMenuScene();
        }
    }
}