using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class TimeController : Singleton<TimeController>
    {
        [SerializeField, Range(0f, 1f)] float bulletTimeScale = 0.1f;
        float defaultFixedDeltaTime;

        float timeScaleBeforePause=1;

   
        protected override void Awake()
        {
            base.Awake();
            defaultFixedDeltaTime = Time.fixedDeltaTime;
            timeScaleBeforePause = Time.timeScale;
        }

        public void Pause()
        {
            timeScaleBeforePause = Time.timeScale;
            Time.timeScale = 0f;
           
        }

        public void Unpause()
        {
            Time.timeScale = timeScaleBeforePause;
           
        }
        public void BulletTime(float duration)
        {
            Time.timeScale = bulletTimeScale;
            StartCoroutine(SlowOutCoroutine(duration));
        }
        public void BulletTime(float inDuration,float outDuration)
        {
            StartCoroutine(SlowInAndOutCoroutine(inDuration,outDuration));
        }
        public void BulletTime(float inDuration, float keepingDuration, float outDuration)
        {
            StartCoroutine(SlowInKeepAndOutDuration(inDuration,keepingDuration,outDuration));
        }
        public void SlowIn(float duration)
        {
            StartCoroutine(SlowInCoroutine(duration));
        }
        public void SlowOut(float duration)
        {
            StartCoroutine(SlowOutCoroutine(duration));
        }
        IEnumerator SlowInKeepAndOutDuration(float inDuration,float keepingDuration,float outDuration)
        {
            yield return SlowInCoroutine(inDuration);
            yield return new WaitForSecondsRealtime(keepingDuration);
            yield return SlowOutCoroutine(outDuration);
        }
        IEnumerator SlowInAndOutCoroutine(float inDuration,float outDuration)
        {
            yield return SlowInCoroutine(inDuration);

            yield return SlowOutCoroutine(outDuration);
        }
        IEnumerator SlowInCoroutine(float duration)
        {
            float startTime = Time.unscaledTime;
            float t = 0f;
            while (t < 1f)
            {
                if (GameManager.CurrentGameState!=GameState.Paused)
                {
                t += Time.unscaledDeltaTime / duration;
                Time.timeScale = Mathf.Lerp(1f,bulletTimeScale,t);
                Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
                }
                yield return null;
            }
            //Debug.Log($"Slow Out Duration:{Time.unscaledTime - startTime}");
        }
        IEnumerator SlowOutCoroutine(float duration)
        {
            float startTime = Time.unscaledTime;
            float t = 0f;
            while (t < 1f)
            {
                if (GameManager.CurrentGameState != GameState.Paused)
                {
                t += Time.unscaledDeltaTime / duration;
                Time.timeScale = Mathf.Lerp(bulletTimeScale,1f,t);
                Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
                }
                yield return null;
            }
            //Debug.Log($"Slow Out Duration:{Time.unscaledTime - startTime}");
        }
    }
}