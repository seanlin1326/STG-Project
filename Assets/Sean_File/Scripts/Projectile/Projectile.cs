using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] GameObject hitVFX;
        [SerializeField] AudioData[] hitSFX;
        [SerializeField]float damage; 
        [SerializeField]protected float moveSpeed = 10f;
        [SerializeField]protected Vector2 moveDirection;
        protected GameObject target;
        IEnumerator MoveDirectlyCoroutine()
        {
            while (gameObject.activeSelf)
            {
                Move();
                yield return null;
            }
        }
        public void Move() => transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        protected virtual void OnEnable()
        {
            StartCoroutine(MoveDirectlyCoroutine());
        }
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent<Charactor>(out Charactor _charactor))
            {
                _charactor.TakeDamage(damage);
                var _contactPoint = collision.GetContact(0);
                PoolManager.Release(hitVFX, _contactPoint.point, Quaternion.LookRotation(_contactPoint.normal));
                AudioManager.Instance.PlayRandomSFX(hitSFX);
                gameObject.SetActive(false);
            }
        }
        protected void SetTarget(GameObject target)
        {
            this.target = target;
        }
    }
}