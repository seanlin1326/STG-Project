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

        [Header("=== Explosion ===")]
        [SerializeField] GameObject explosionVFX;
        [SerializeField] AudioData explosionSFX;
        [SerializeField] float explosionRadius = 3f;
        [SerializeField] float explosionDamage = 100f;
        [SerializeField] LayerMask enemyLayerMask = default;


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
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);
            //Spawn a explosion VFX
            PoolManager.Release(explosionVFX, transform.position);
            //Play explosion SFX
            AudioManager.Instance.PlayRandomSFX(explosionSFX);
            //Enemies in explosion take AOE damage
            var colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyLayerMask);

            foreach (var collider in colliders)
            {
                if(collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    enemy.TakeDamage(explosionDamage);
                }
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position,explosionRadius);
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