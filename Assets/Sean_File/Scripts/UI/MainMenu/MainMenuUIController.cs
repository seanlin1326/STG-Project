using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sean
{
    public class MainMenuUIController : MonoBehaviour
    {
        [SerializeField] private Button buttonStartGame;
        private void OnEnable()
        {
            buttonStartGame.onClick.AddListener(OnStartGameButtonClick);
        }
        private void OnDisable()
        {
            buttonStartGame.onClick.RemoveAllListeners();
        }
        private void OnStartGameButtonClick()
        {
            SceneLoader.Instance.LoadGamePlayScene();
        }
    }
}