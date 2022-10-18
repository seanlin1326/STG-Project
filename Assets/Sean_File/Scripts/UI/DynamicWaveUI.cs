using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class DynamicWaveUI : MonoBehaviour
    {
        #region -- Fields --
        [SerializeField] float animationTime = 1f;
        [Header("---- Line Move ----")]
        [SerializeField] Vector2 lineTopStartPosition = new Vector2(-1250f, 140f);
        [SerializeField] Vector2 lineTopTargetPosition = new Vector2(0f, 140f);
        [SerializeField] Vector2 lineBottomStartPosition = new Vector2(1250f,0f);
        [SerializeField] Vector2 lineBottomTargetPosition = Vector2.zero;

        [Header("---- Text Scale ----")]
        [SerializeField] Vector2 waveTextStartScale = new Vector2(1f, 0f);
        [SerializeField] Vector2 waveTextTargetScale = Vector2.one;

        [SerializeField]RectTransform lineTop;
        [SerializeField]RectTransform lineBottom;
        [SerializeField]RectTransform waveText;

        WaitForSeconds waitStayTime;
        #endregion
        #region -- Unity Event Functions --
        private void Awake()
        {
            //if(TryGetComponent<Animator>(out Animator animator))
            //{
            //    if (animator.isActiveAndEnabled)
            //    {
            //        Destroy(this);
            //    }
            //}
            waitStayTime = new WaitForSeconds(EnemyManager.Instance.TimeBetweenWaves - animationTime * 2);
            lineTop.localPosition = lineTopStartPosition;
            lineBottom.localPosition = lineBottomStartPosition;
            waveText.localScale = waveTextStartScale;
        }
        #endregion
        private void OnEnable()
        {
            StartCoroutine(LineMoveCoroutine(lineTop,lineTopTargetPosition,lineTopStartPosition));
            StartCoroutine(LineMoveCoroutine(lineBottom,lineBottomTargetPosition,lineBottomStartPosition));
            StartCoroutine(TextScaleCoroutine(waveText,waveTextTargetScale,waveTextStartScale));
        }
        #region -- Line Move --
        IEnumerator LineMoveCoroutine(RectTransform rect,Vector2 targetPosition,Vector2 startPosition)
        {
            yield return StartCoroutine(UIMoveCoroutine(rect,targetPosition));
            yield return waitStayTime;
            yield return StartCoroutine(UIMoveCoroutine(rect,startPosition));
        }
        IEnumerator UIMoveCoroutine(RectTransform rect,Vector2 position)
        {
            float _timer = 0f;
            var previousLocalPosition = rect.localPosition;
            while (_timer<1f)
            {
                _timer += Time.deltaTime / animationTime;
                rect.localPosition = Vector2.Lerp(previousLocalPosition, position,_timer);
                yield return null;
            }
        }
        #endregion
        #region -- TextScale --
        IEnumerator TextScaleCoroutine(RectTransform rect,Vector2 targetScale,Vector2 startScale)
        {
            yield return StartCoroutine(UIScaleCoroutine(rect,targetScale));
            yield return waitStayTime;
            yield return StartCoroutine(UIScaleCoroutine(rect,startScale));
        }
        IEnumerator UIScaleCoroutine(RectTransform rect,Vector2 scale)
        {
            float _timer = 0f;
            var previousLocalScale = rect.localScale;
            while (_timer < 1f)
            {
                _timer += Time.deltaTime / animationTime;
                rect.localScale = Vector2.Lerp(previousLocalScale, scale,_timer);
                yield return null;
            }
        }
        #endregion
    }
}