using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Enemy : Charactor
    {
        [SerializeField]int scorePoint = 100;
        [SerializeField] int deathEnergyBonus = 3;
        public override void Die()
        {
            ScoreManager.Instance.AddScore(scorePoint);
            PlayerEnergy.Instance.Obtain(deathEnergyBonus);
            EnemyManager.Instance.RemoveFromList(gameObject);
            base.Die();
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.TryGetComponent<Player>(out Player player))
            {
                player.Die();
                Die();
            }
        }
    }
}