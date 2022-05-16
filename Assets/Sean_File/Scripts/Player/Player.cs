using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Player : MonoBehaviour
    {
        [SerializeField] PlayerInput input;

        [SerializeField] float moveSpeed = 10f;

        [SerializeField] float accelerationTime = 0.2f;
        [SerializeField] float decelerationTime = 0.2f;

        [SerializeField] float moveRotationAngle = 50f;

        [SerializeField] float paddingX = 0.2f;
        [SerializeField] float paddingY = 0.2f;
        new Rigidbody2D rigidbody;
        Coroutine moveCoroutine;
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
        private void OnEnable()
        {
            input.onMove += Move;
            input.onStopMove += StopMove;
        }
        private void OnDisable()
        {
            input.onMove -= Move;
            input.onStopMove -= StopMove;
        }
        // Start is called before the first frame update
        void Start()
        {
            rigidbody.gravityScale = 0;
            input.EnableGamePlayInput();
        }

        // Update is called once per frame
        void Update()
        {

        }
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
    }
}