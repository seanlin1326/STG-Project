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
        [Header("=== Canvas ===")]
        [SerializeField] Canvas hudCanvas;
        [SerializeField] Canvas menusCanvas;
        [Header("=== Player Input ===")]
        [SerializeField] Button resumeButton;
        [SerializeField] Button optionsButton;
        [SerializeField] Button mainMenuButton;
        private void OnEnable()
        {
            playerInput.onPause += Pause;
            playerInput.onUnpause += Unpause;

            resumeButton.onClick.AddListener(OnResumeButtonClick);
            optionsButton.onClick.AddListener(OnOptionsButtonClick);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
        }
        private void OnDisable()
        {
            playerInput.onPause -= Pause;
            playerInput.onUnpause -= Unpause;

            resumeButton.onClick.RemoveAllListeners();
            optionsButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.RemoveAllListeners();
        }
        private void Pause()
        {
            Time.timeScale = 0f;
            hudCanvas.enabled = false;
            menusCanvas.enabled = true;
            playerInput.EnablePauseMenuInput();
            playerInput.SwitchToDynamicUpdateMode();
        }
        public void Unpause()
        {
            OnResumeButtonClick();
        }
        void OnResumeButtonClick()
        {
            Time.timeScale = 1f;
            hudCanvas.enabled = true;
            menusCanvas.enabled = false;
            playerInput.EnableGamePlayInput();
            playerInput.SwitchToFixedUpdateMode();
        }
        void OnOptionsButtonClick()
        {
            //TODO
        }
        void OnMainMenuButtonClick()
        {
            menusCanvas.enabled = false;
            Time.timeScale = 1f;
            //Load Main Menu Scene
            SceneLoader.Instance.LoadMainMenuScene();
        }
    }
}