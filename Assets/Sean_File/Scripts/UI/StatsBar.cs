using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sean
{
    public class StatsBar : MonoBehaviour
    {
        [SerializeField] Image fillImageBack;
        [SerializeField] Image fillImageFront;

        [SerializeField] bool delayFill = true;
        [SerializeField] float fillDelayTime = 0.5f;
        [SerializeField] float fillSpeed=0.1f;
        float currentFillAmount;
      protected  float targetFillAmount;

        Coroutine bufferedFillingCoroutine;
        
        Canvas canvas;
        //float t;
        private void Awake()
        {
            canvas = GetComponent<Canvas>();
            canvas.worldCamera = Camera.main;
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        public virtual void Initialize(float _currentValue,float _maxValue)
        {
            currentFillAmount = _currentValue / _maxValue;
            targetFillAmount = currentFillAmount;

            fillImageBack.fillAmount = currentFillAmount;
            fillImageFront.fillAmount = currentFillAmount;
        }
        public void UpdateStats(float _currentValue,float _maxValue)
        {
            targetFillAmount = _currentValue / _maxValue;
            if(bufferedFillingCoroutine != null)
            {
                StopCoroutine(bufferedFillingCoroutine);
            }
            //if stats reduce 當狀態減少時
            if (currentFillAmount > targetFillAmount)
            {
                //fill image front's fill amount = target fill amount 前面圖片的填充值 = 目標填充值
                fillImageFront.fillAmount = targetFillAmount;
                //slowly reduce fill image back's fill amount 慢慢減少後面圖片的填充值
           bufferedFillingCoroutine = StartCoroutine(BufferedFillingCo(fillImageBack));
            }
            //if stats increace 當狀態增加值
          else if (currentFillAmount < targetFillAmount)
            {
                //fill image back's fill amount= target fill amount 後面圖片的填充值 = 目標填充值
                fillImageBack.fillAmount = targetFillAmount;
                //slowly increace fill image back's fill amount 慢慢減少前面圖片的填充值
             bufferedFillingCoroutine =  StartCoroutine(BufferedFillingCo(fillImageFront));
            }
        }
     protected virtual IEnumerator BufferedFillingCo(Image _image)
        {
            if(delayFill)
            {
                yield return new WaitForSeconds(fillDelayTime);
            }
           float _t = 0;
            while(_t < 1f)
            {
               
                _t += Time.deltaTime * fillSpeed;
                currentFillAmount = Mathf.Lerp(currentFillAmount,targetFillAmount,_t);
                _image.fillAmount = currentFillAmount;
                yield return null;
            }
        }
    }
}