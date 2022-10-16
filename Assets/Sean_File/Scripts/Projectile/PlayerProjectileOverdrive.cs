using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class PlayerProjectileOverdrive : PlayerProjectile
    {
        [SerializeField] ProjectileGuidanceSystem guidanceSystem;
        
      
        protected override void OnEnable()
        {
            GameObject enemyTarget = EnemyManager.Instance.RandomEnemy;
            SetTarget(enemyTarget);
            transform.rotation = Quaternion.identity;
            if (target == null)
            {
                base.OnEnable();
            }
            else
            {
                //track target
                StartCoroutine(guidanceSystem.HomingCoroutine(target));
            }
        }
    }
}