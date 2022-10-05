﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
namespace Sean
{
    public class Player : Charactor
    {
        [SerializeField] StatsBar_HUD statsBar_HUD;

       [SerializeField] bool regenerateHealth = true;
        [SerializeField] float healthGenerateTime;
        [SerializeField,Range(0f,1f)] float healthGeneratePercent;

        [Header("--- Input ---")]
        [SerializeField] PlayerInput input;
        [Header("--- Move ---")]
        [SerializeField] float moveSpeed = 10f;

        [SerializeField] float accelerationTime = 0.2f;
        [SerializeField] float decelerationTime = 0.2f;

        [SerializeField] float moveRotationAngle = 50f;

        [SerializeField] float paddingX = 0.2f;
        [SerializeField] float paddingY = 0.2f;
        [Header("--- Fire ---")]
        [SerializeField] GameObject projectile1;
        [SerializeField] GameObject projectile2;
        [SerializeField] GameObject projectile3;
        //Shoot projectile start point
        [SerializeField] Transform muzzleTop;
        [SerializeField] Transform muzzleMiddle;
        [SerializeField] Transform muzzleBottom;
        [SerializeField] AudioData playerProjectileLaunchSFX;
        [SerializeField, Range(1, 3)] int weaponPower=1;

        [SerializeField] float fireInterval=0.2f;
        [Header("--- Dodge ---")]
        [SerializeField] AudioData dodgeSFX;
         [SerializeField,Range(0,199)] int dodgeEnergyCost=25;
        [SerializeField] float maxRoll = 720f;
        [SerializeField] float rollSpeed = 360f;
        [SerializeField] Vector3 dodgeScale = new Vector3(0.5f, 0.5f, 0.5f);
        float currentRoll;
        float dodgeDuration;
        bool isDodging=false;


        new Rigidbody2D rigidbody;
        new Collider2D collider;
        Coroutine moveCoroutine;
        Coroutine healthGenerateCoroutine;
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            collider = GetComponent<Collider2D>();
            dodgeDuration = maxRoll / rollSpeed;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            input.onMove += Move;
            input.onStopMove += StopMove;
            input.onFire += Fire;
            input.onStopFire += StopFire;
            input.onDodge += Dodge;
        }
        private void OnDisable()
        {
            input.onMove -= Move;
            input.onStopMove -= StopMove;
            input.onFire -= Fire;
            input.onStopFire -= StopFire;
            input.onDodge -= Dodge;
        }
        // Start is called before the first frame update
        void Start()
        {
           
            rigidbody.gravityScale = 0;
            input.EnableGamePlayInput();
            statsBar_HUD.Initialize(health,maxHealth);
           
        }
        public override void TakeDamage(float _damage)
        {
            base.TakeDamage(_damage);
            statsBar_HUD.UpdateStats(health, maxHealth);
            if (gameObject.activeSelf)
            {
                if (regenerateHealth)
                {
                    if (healthGenerateCoroutine != null)
                        StopCoroutine(healthGenerateCoroutine);
                    healthGenerateCoroutine = StartCoroutine(HealthRegenerateCo(healthGenerateTime,healthGeneratePercent));
                }
            }
        }
        public override void RestoreHealth(float _value)
        {
            base.RestoreHealth(_value);
            statsBar_HUD.UpdateStats(health, maxHealth);
        }
        public override void Die()
        {
            statsBar_HUD.UpdateStats(0, maxHealth);
            base.Die();
        }
        // Update is called once per frame
        void Update()
        {

        }
        #region -- Move --
        private void Move(Vector2 _moveInput)
        {
            if (moveCoroutine != null)
                StopCoroutine(moveCoroutine);

            Quaternion _moveRotation = Quaternion.AngleAxis(moveRotationAngle * _moveInput.y, Vector3.right);

            moveCoroutine = StartCoroutine(MoveCo(accelerationTime, _moveInput.normalized * moveSpeed, _moveRotation));
            StartCoroutine(nameof(MovePositionLimitCo));
        }
        void StopMove()
        {
            if (moveCoroutine != null)
                StopCoroutine(moveCoroutine);
            StartCoroutine(MoveCo(decelerationTime, Vector2.zero, Quaternion.identity));
            StopCoroutine(nameof(MovePositionLimitCo));
        }
        IEnumerator MoveCo(float _time, Vector2 _moveVelocity, Quaternion _moveRotation)
        {
            float _t = 0;
            while (_t < _time)
            {
                _t += Time.fixedDeltaTime ;
                rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, _moveVelocity, _t /_time);
                transform.rotation = Quaternion.Lerp(transform.rotation, _moveRotation, _t/_time);
                yield return null;
            }
        }

        IEnumerator MovePositionLimitCo()
        {
            while (true)
            {
                transform.position = Viewport.Instance.PlayerMovablePosition(transform.position, paddingX, paddingY);
                yield return null;
            }
        }
        #endregion
        #region -- Fire --
        void Fire()
        {
            StartCoroutine(nameof(FireCo));
        }
        void StopFire()
        {
            StopCoroutine(nameof(FireCo));
        }
        IEnumerator FireCo()
        {
            
            while (true)
            {
              
                switch (weaponPower)
                {
                    case 1:
                        PoolManager.Release(projectile1, muzzleMiddle.position);
                        break;
                    case 2:
                        PoolManager.Release(projectile1, muzzleTop.position);
                        PoolManager.Release(projectile1, muzzleBottom.position);
                        break;
                    case 3:
                        PoolManager.Release(projectile1, muzzleMiddle.position);
                        PoolManager.Release(projectile2, muzzleTop.position);
                        PoolManager.Release(projectile3, muzzleBottom.position);
                        break;

                }
                AudioManager.Instance.PlayRandomSFX(playerProjectileLaunchSFX);
                yield return new WaitForSeconds(fireInterval);
            }
        }
        #endregion
        #region -- Dodge --
        void Dodge()
        {
           
            if (isDodging || !PlayerEnergy.Instance.IsEnough(dodgeEnergyCost)) return;
            StartCoroutine(nameof(DodgeCoroutine));
            //Change player's scale 改變玩家的縮放值
        }
        IEnumerator DodgeCoroutine()
        {
            isDodging = true;
            AudioManager.Instance.PlayRandomSFX(dodgeSFX);
            //Cost Energy 消耗能量
            PlayerEnergy.Instance.Use(dodgeEnergyCost);
            //Make player invincible 讓玩家無敵
            collider.isTrigger = true;
            //Make player rotate along x axis 讓玩家沿著x軸旋轉
            currentRoll = 0;

            #region -- Method 1 --
            //float _t1 = 0;
            //float _t2 = 0;
            //while(currentRoll < maxRoll)
            //{
            //    Debug.Log(currentRoll);
            //    currentRoll += rollSpeed * Time.deltaTime;
            //    transform.rotation = Quaternion.AngleAxis(currentRoll,Vector3.right);
            //    if(currentRoll < maxRoll / 2)
            //    {
            //        _t1 += Time.deltaTime / (dodgeDuration);
            //        transform.localScale = Vector3.Lerp(transform.localScale, dodgeScale, _t1);

            //    }
            //    else
            //    {
            //        _t2 += Time.deltaTime / (dodgeDuration/2);
            //        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, _t2);

            //    }
            //   yield return null;
            //}
            #endregion
            #region -- Method 2 --
            while (currentRoll < maxRoll)
            {
              
                currentRoll += rollSpeed * Time.deltaTime;
                transform.rotation = Quaternion.AngleAxis(currentRoll, Vector3.right);
              transform.localScale=  BezierCurve.QuadraticPoint(Vector3.one, Vector3.one, dodgeScale, currentRoll / maxRoll);
                yield return null;
            }
            #endregion

            collider.isTrigger = false;
            isDodging = false;
        }
        #endregion
    }
}