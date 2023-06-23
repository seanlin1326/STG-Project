using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sean
{
    public class MainMenuUIController : MonoBehaviour
    {
        [Header("=== Canvas ===")]
        [SerializeField] Canvas mainMenuCanvas;
        [Header("=== Buttons ===")]
        [SerializeField] private Button buttonStartGame;
        [SerializeField] private Button buttonOptions;
        [SerializeField] private Button buttonQuit;
        private void OnEnable()
        {
            ButtonPressedBehavior.buttonFunctionTable.Add(buttonStartGame.gameObject.name, OnStartGameButtonClick);
            ButtonPressedBehavior.buttonFunctionTable.Add(buttonOptions.gameObject.name, OnButtonOptionsClicked);
            ButtonPressedBehavior.buttonFunctionTable.Add(buttonQuit.gameObject.name, OnButtonQuitClicked);
        }
        private void OnDisable()
        {
            ButtonPressedBehavior.buttonFunctionTable.Clear();
        }
        private void Start()
        {
            UIInput.Instance.SelectUI(buttonStartGame);
        }
        private void OnStartGameButtonClick()
        {
            mainMenuCanvas.enabled = false;
            SceneLoader.Instance.LoadGamePlayScene();
        }

        private void OnButtonOptionsClicked()
        {
            UIInput.Instance.SelectUI(buttonOptions);
        }

        private void OnButtonQuitClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}