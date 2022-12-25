using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class PlayerMissile : PlayerProjectileOverdrive
    {
        [SerializeField] AudioData targetAcuiredVoice;
        [Header("=== Speed Setting ===")]
        [SerializeField] float lowSpeed = 8f;
        [SerializeField] float highSpeed = 25f;
        [SerializeField] float variableSpeedDelay = 0.5f;

        WaitForSeconds waitVariableSpeedDelay;
        protected override void Awake()
        {
            base.Awake();
            waitVariableSpeedDelay = new WaitForSeconds(variableSpeedDelay);
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            StartCoroutine(nameof(VariableSpeedCoroutine));
        }
        IEnumerator VariableSpeedCoroutine()
        {
            moveSpeed = lowSpeed;
            yield return waitVariableSpeedDelay;
            moveSpeed = highSpeed;
            if (target != null)
            {
                AudioManager.Instance.PlayRandomSFX(targetAcuiredVoice);
            }
        }
    }
}