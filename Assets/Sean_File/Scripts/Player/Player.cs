using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Player : Charactor
    {
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
        [Header("Fire")]
        [SerializeField] GameObject projectile1;
        [SerializeField] GameObject projectile2;
        [SerializeField] GameObject projectile3;
        //�l�u�ͦ��I
        [SerializeField] Transform muzzleTop;
        [SerializeField] Transform muzzleMiddle;
        [SerializeField] Transform muzzleBottom;

        [SerializeField, Range(1, 3)] int weaponPower=1;

        [SerializeField] float fireInterval=0.2f;
        new Rigidbody2D rigidbody;
        Coroutine moveCoroutine;
        Coroutine healthGenerateCoroutine;
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            input.onMove += Move;
            input.onStopMove += StopMove;
            input.onFire += Fire;
            input.onStopFire += StopFire;
        }
        private void OnDisable()
        {
            input.onMove -= Move;
            input.onStopMove -= StopMove;
            input.onFire -= Fire;
            input.onStopFire -= StopFire;
        }
        // Start is called before the first frame update
        void Start()
        {
           
            rigidbody.gravityScale = 0;
            input.EnableGamePlayInput();
           
        }
        public override void TakeDamage(float _damage)
        {
            base.TakeDamage(_damage);
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
            StartCoroutine(MovePositionLimitCo());
        }
        void StopMove()
        {
            if (moveCoroutine != null)
                StopCoroutine(moveCoroutine);
            StartCoroutine(MoveCo(decelerationTime, Vector2.zero, Quaternion.identity));
            StopCoroutine(MovePositionLimitCo());
        }
        IEnumerator MoveCo(float _time, Vector2 _moveVelocity, Quaternion _moveRotation)
        {
            float _t = 0;
            while (_t < _time)
            {
                _t += Time.fixedDeltaTime / _time;
                rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, _moveVelocity, _t / _time);
                transform.rotation = Quaternion.Lerp(transform.rotation, _moveRotation, _t / _time);
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
                yield return new WaitForSeconds(fireInterval);
            }
        }
        #endregion
    }
}