using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class PlayerProjectile : Projectile
    {
        TrailRenderer trail;
        private void Awake()
        {
            trail = GetComponentInChildren<TrailRenderer>();
        }
        private void OnDisable()
        {
            trail.Clear();
        }
    }
}