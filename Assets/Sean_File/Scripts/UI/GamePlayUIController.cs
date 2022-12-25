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

            ButtonPressedBehavior.buttonFunctionTable.Add(resumeButton.gameObject.name,OnResumeButtonClick);
            ButtonPressedBehavior.buttonFunctionTable.Add(optionsButton.gameObject.name,OnOptionsButtonClick);
            ButtonPressedBehavior.buttonFunctionTable.Add(mainMenuButton.gameObject.name, OnMainMenuButtonClick);
        }
        private void OnDisable()
        {
            playerInput.onPause -= Pause;
            playerInput.onUnpause -= Unpause;
        }
        private void Pause()
        {
            Time.timeScale = 0f;
            hudCanvas.enabled = false;
            menusCanvas.enabled = true;
            playerInput.EnablePauseMenuInput();
            playerInput.SwitchToDynamicUpdateMode();
            UIInput.Instance.SelectUI(resumeButton);
        }
        public void Unpause()
        {
            resumeButton.Select();
            resumeButton.animator.SetTrigger("Pressed");
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
            UIInput.Instance.SelectUI(optionsButton);
            playerInput.EnablePauseMenuInput();
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