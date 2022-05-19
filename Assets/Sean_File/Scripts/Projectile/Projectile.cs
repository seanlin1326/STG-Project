using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] GameObject hitVFX;
        [SerializeField]float damage; 
        [SerializeField]protected float moveSpeed = 10f;
        [SerializeField]protected Vector2 moveDirection;

        IEnumerator MoveDirectlyCo()
        {
            while (gameObject.activeSelf)
            {
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        protected virtual void OnEnable()
        {
            StartCoroutine(MoveDirectlyCo());
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent<Charactor>(out Charactor _charactor))
            {
                _charactor.TakeDamage(damage);
                var _contactPoint = collision.GetContact(0);
                PoolManager.Release(hitVFX, _contactPoint.point, Quaternion.LookRotation(_contactPoint.normal));
                gameObject.SetActive(false);
            }
        }
    }
}