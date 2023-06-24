using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Sean
{
    public class SceneLoader : PersistenSingleton<SceneLoader>
    {
        [SerializeField] Image transitionImage;
        [SerializeField] float defaultFadeTime = 3.5f;
        [SerializeField] CanvasGroup transitionImageCanvasGroup;
        const string GamePlaySceneName = "GamePlay";
        const string MainMenuSceneName = "MainMenu";
        const string ScoringSceneName = "Scoring";
        private void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        IEnumerator LoadingCoroutine(string sceneName)
        {
            transitionImageCanvasGroup.alpha = 0;
            var loadingOperation= SceneManager.LoadSceneAsync(sceneName);
            loadingOperation.allowSceneActivation = false;
            float alphaFadeInSpeed = 1 / defaultFadeTime;
            //fade out
            while (transitionImageCanvasGroup.alpha < 1f)
            {
                transitionImageCanvasGroup.alpha += Time.unscaledDeltaTime * alphaFadeInSpeed;
                yield return null;
            }
            transitionImageCanvasGroup.alpha = 1;
            //load new scene

            yield return new WaitUntil(() => loadingOperation.progress >=0.9f);

            loadingOperation.allowSceneActivation = true;
            while (transitionImageCanvasGroup.alpha > 0f)
            {
                transitionImageCanvasGroup.alpha -= Time.unscaledDeltaTime * alphaFadeInSpeed;
                yield return null;
            }
            transitionImageCanvasGroup.alpha = 0;
            //fade in
        }
        public void LoadGamePlayScene()
        {
            StopAllCoroutines();
            StartCoroutine(LoadingCoroutine(GamePlaySceneName));
        }
        public void LoadMainMenuScene()
        {
            StopAllCoroutines();
            StartCoroutine(LoadingCoroutine(MainMenuSceneName));
        }
        public void LoadScoringScene()
        {
            StopAllCoroutines();
            StartCoroutine(LoadingCoroutine(ScoringSceneName));
        }
    }
}