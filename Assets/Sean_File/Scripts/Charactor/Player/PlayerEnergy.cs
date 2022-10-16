using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sean
{
    public class PlayerEnergy : Singleton<PlayerEnergy>
    {
       [SerializeField] EnergyBar energyBar;
       [SerializeField]float overdriveInterval = 0.1f;
        public const int MAX = 100;
        public const int PERCENT = 1;
        int energy;
        bool available = true;
        private void OnEnable()
        {
            PlayerOverdrive.on += PlayerOverDriveOn;
            PlayerOverdrive.off += PlayerOverDriveOff;
        }
        private void OnDisable()
        {
            PlayerOverdrive.on -= PlayerOverDriveOn;
            PlayerOverdrive.off -= PlayerOverDriveOff;
        }
        private void Start()
        {
            energyBar.Initialize(energy, MAX);
            Obtain(MAX);

        }
        public void Obtain(int _value)
        {
            if (energy == MAX || !available || !gameObject.activeSelf)
            {
                return;
            }
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
            if(energy ==0 && !available)
            {
                PlayerOverdrive.off.Invoke();
            }
        }
        public bool IsEnough(int _value) => energy >= _value;
        void PlayerOverDriveOn()
        {
            available = false;
            StartCoroutine(nameof(KeepUsingCoroutine));
        }
        void PlayerOverDriveOff()
        {
            available = true;
            StopCoroutine(nameof(KeepUsingCoroutine));
        }
        IEnumerator KeepUsingCoroutine()
        {
            while(gameObject.activeSelf && energy > 0)
            {
                //every 0.1s seconds
                yield return new WaitForSeconds(overdriveInterval);
                //use 1% of max energy， every 1 second use 10% of max energy
                //means that overdrive last for 10 seconds
                Use(PERCENT);
            }
        }

    }
}