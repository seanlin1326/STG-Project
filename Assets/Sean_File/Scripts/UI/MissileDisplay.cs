using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sean
{
    public class MissileDisplay : MonoBehaviour
    {
        static Text amountText;
        static Image cooldownImage;
        private void Awake()
        {
            amountText = transform.Find("Amount Text").GetComponent<Text>();
            cooldownImage = transform.Find("CooldownImage").GetComponent<Image>();
        }
        public static void UpdateAmountText(int amount)
        {
            amountText.text = amount.ToString();
        }
        public static void UpdateCooldownImage(float fillAmount) => cooldownImage.fillAmount = fillAmount;
    }
}