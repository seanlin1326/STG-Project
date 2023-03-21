using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Sean
{
    public class MissileSystem : MonoBehaviour
    {
        [SerializeField] private int defaultAmount = 5;
        [SerializeField] private float cooldownTime = 1f;
        [SerializeField] private GameObject missilePrefab;
        [SerializeField] private AudioData launchSFX;

        private bool isReady = true;

        private int amount;

        private void Awake()
        {
            amount = defaultAmount;
        }
        private void Start()
        {
            MissileDisplay.UpdateAmountText(amount);
        }

        public void Launch(Transform muzzleTransform)
        {
            if(amount == 0 || !isReady)
            {
                return;
            }
            isReady = false;
            //Release a missile clone from object pool
            PoolManager.Release(missilePrefab, muzzleTransform.position);
            //Play missile launch SFX
            AudioManager.Instance.PlayRandomSFX(launchSFX);

            amount -= 1;
            MissileDisplay.UpdateAmountText(amount);

            if(amount == 0)
            {
                MissileDisplay.UpdateCooldownImage(1f);
            }
            else
            {
                //cooldown missile launching
                StartCoroutine(CooldownCoroutine());
            }
        }
        
        IEnumerator CooldownCoroutine()
        {
            var cooldownValue = cooldownTime;
            while(cooldownValue > 0f)
            {
                MissileDisplay.UpdateCooldownImage(cooldownValue / cooldownTime);
                cooldownValue = Mathf.Max(cooldownValue - Time.deltaTime, 0f);

                yield return null;
            }
            isReady = true;
        }

    }
}