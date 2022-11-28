using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class GamePlayUIController : MonoBehaviour
    {
        [SerializeField] PlayerInput playerInput;
        [SerializeField] Canvas hudCanvas;
        [SerializeField] Canvas menusCanvas;

        private void OnEnable()
        {
            playerInput.onPause += Pause;
            playerInput.onUnpause += Unpause;
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
        }
        private void Unpause()
        {
            Time.timeScale = 1f;
            hudCanvas.enabled = true;
            menusCanvas.enabled = false;
            playerInput.EnableGamePlayInput();
            playerInput.SwitchToFixedUpdateMode();
        }

    }
}