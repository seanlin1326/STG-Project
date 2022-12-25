using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class MissileSystem : MonoBehaviour
    {
        [SerializeField] GameObject missilePrefab;
        [SerializeField] AudioData launchSFX;
       public void Launch(Transform muzzleTransform)
       {
            //Release a missile clone from object pool
            //Play missile launch SFX
            PoolManager.Release(missilePrefab, muzzleTransform.position);
            AudioManager.Instance.PlayRandomSFX(launchSFX);
        }
    }
}