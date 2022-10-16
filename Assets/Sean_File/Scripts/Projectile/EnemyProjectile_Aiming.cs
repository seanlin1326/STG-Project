using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class EnemyProjectile_Aiming : Projectile
    {
       
        private void Awake()
        {
           SetTarget(GameObject.FindGameObjectWithTag("Player"));
        }
        protected override void OnEnable()
        {
            StartCoroutine(nameof(MoveDirectionCo));  
            base.OnEnable();
        }
        IEnumerator MoveDirectionCo()
        {
            yield return null;
            if (target != null&&target.activeSelf)
                moveDirection = (target.transform.position - transform.position).normalized;
        }
    }
}