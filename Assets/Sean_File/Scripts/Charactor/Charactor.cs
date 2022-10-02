using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Charactor : MonoBehaviour
    {
        [Header("---Death---")]
        [SerializeField] GameObject deathVFX;
        [SerializeField] AudioData[] deathSFX;
        [Header("---Health---")]
        [SerializeField] protected float maxHealth = 1;

        [SerializeField]protected float health = 1;

       [SerializeField] StatsBar onHeadHealthBar;
        [SerializeField] bool showOnHeadHealthBar=true;
        protected virtual void OnEnable()
        {
            health = maxHealth;
            if (showOnHeadHealthBar)
            {
                ShowOnHeadHealthBar();
            }
            else
            {
                HideOnHeadHealthBar();
            }
        }
        public void ShowOnHeadHealthBar()
        {
            onHeadHealthBar.gameObject.SetActive(true);
            onHeadHealthBar.Initialize(health, maxHealth);
        }
        public void HideOnHeadHealthBar()
        {
            onHeadHealthBar.gameObject.SetActive(false);
        }
        public virtual void TakeDamage(float _damage)
        {
            health -= _damage;

            if (showOnHeadHealthBar && gameObject.activeSelf)
            {
                onHeadHealthBar.UpdateStats(health, maxHealth);
            }

            if (health <= 0f)
            {
                Die();
            }
        }
        public virtual void Die()
        {
            health = 0f;
            AudioManager.Instance.PlayRandomSFX(deathSFX);
            PoolManager.Release(deathVFX,transform.position);
            gameObject.SetActive(false);
        }
        public virtual void RestoreHealth(float _value)
        {
            if (health == maxHealth) return;
            health = Mathf.Clamp(health+_value, 0, maxHealth);
        }
        protected IEnumerator HealthRegenerateCo(float _waitTime,float _percent)
        {
            while(health < maxHealth)
            {
                yield return new WaitForSeconds(_waitTime);
                RestoreHealth(maxHealth * _percent);
            }
        }
        protected IEnumerator DamageOverTimeCo(float _waitTime, float _percent)
        {
            while (health > 0)
            {
                yield return new WaitForSeconds(_waitTime);
                TakeDamage(maxHealth * _percent);
            }
        }
    }
}