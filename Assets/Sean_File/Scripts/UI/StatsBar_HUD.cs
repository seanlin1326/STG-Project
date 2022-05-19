using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sean
{
    public class StatsBar_HUD : StatsBar
    {
        [SerializeField] Text percentText;
        void SetPercentText()
        {
            percentText.text = Mathf.RoundToInt(targetFillAmount * 100f)+ "%";
        }
        public override void Initialize(float _currentValue, float _maxValue)
        {
            base.Initialize(_currentValue, _maxValue);
            SetPercentText();
        }
        protected override IEnumerator BufferedFillingCo(Image _image)
        {
            SetPercentText();
            return base.BufferedFillingCo(_image);
        }
    }
}