using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] float explosionDamage = 100f;
        [SerializeField] Collider2D explosionCollider;

        WaitForSeconds waitExplosionTime = new WaitForSeconds(0.1f);
        private void OnEnable()
        {
            StartCoroutine(ExplosionCoroutine());
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            //If there is any anemy within the trigger range,the eneny takes explosion damage
            //當檢測到任何敵人在觸發器範圍內，則敵人受到爆炸傷害
            if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(explosionDamage);
            }
        }
        IEnumerator ExplosionCoroutine()
        {
            //Enable the explosion collider when this VFX Spawned
            //當特效生成時啟用爆炸檢測碰撞體
            explosionCollider.enabled = true;

            yield return waitExplosionTime;

            ////Disable the explosion collider
            ////爆炸檢測完畢後關閉碰撞體
            explosionCollider.enabled = false;
        }
    }
}