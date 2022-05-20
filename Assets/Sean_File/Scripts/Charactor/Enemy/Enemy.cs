using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Enemy : Charactor
    {
        [SerializeField] int deathEnergyBonus = 3;
        public override void Die()
        {
            PlayerEnergy.Instance.Obtain(deathEnergyBonus);
            base.Die();
        }
    }
}