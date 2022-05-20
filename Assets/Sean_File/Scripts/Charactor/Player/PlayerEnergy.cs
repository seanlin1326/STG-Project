using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sean
{
    public class PlayerEnergy : Singleton<PlayerEnergy>
    {
       [SerializeField] EnergyBar energyBar;
        public const int MAX = 100;
        public const int PERCENT = 1;
        int energy;
        private void Start()
        {
            energyBar.Initialize(energy, MAX);
            Obtain(MAX);

        }
        public void Obtain(int _value)
        {
            if (energy == MAX)
                return;
            energy = Mathf.Clamp(energy + _value, 0, MAX);
            energyBar.UpdateStats(energy, MAX);
        }
        public void Use(int _value)
        {
            if (!IsEnough(_value))
            {
                Debug.Log("能量不夠");
                return;
            }
            energy = Mathf.Clamp(energy - _value, 0, MAX);
            energyBar.UpdateStats(energy, MAX);
        }
        public bool IsEnough(int _value) => energy >= _value;
    }
}