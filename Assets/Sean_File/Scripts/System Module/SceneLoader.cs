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
        private void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
        public void LoadGamePlayScene()
        {
            StartCoroutine(LoadCoroutine(GamePlaySceneName,defaultFadeTime));
        }
        IEnumerator LoadCoroutine(string sceneName,float fadeTime)
        {
            transitionImageCanvasGroup.alpha = 0;
            var loadingOperation= SceneManager.LoadSceneAsync(sceneName);
            loadingOperation.allowSceneActivation = false;
            float alphaFadeInSpeed = 1 / fadeTime;
            //fade out
            while (transitionImageCanvasGroup.alpha < 1f)
            {
                transitionImageCanvasGroup.alpha += Time.unscaledDeltaTime * alphaFadeInSpeed;
                yield return null;
            }
            transitionImageCanvasGroup.alpha = 1;
            //load new scene
         
            loadingOperation.allowSceneActivation = true;
            while (transitionImageCanvasGroup.alpha > 0f)
            {
                transitionImageCanvasGroup.alpha -= Time.unscaledDeltaTime * alphaFadeInSpeed;
                yield return null;
            }
            transitionImageCanvasGroup.alpha = 0;
            //fade in 

        }
    }
}