using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerInput input;

    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float paddingX = 0.2f;
    [SerializeField] float paddingY = 0.2f;
   new  Rigidbody2D rigidbody;
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
        Vector2 _moveAmount = _moveInput * moveSpeed;
        rigidbody.velocity = _moveAmount;
        StartCoroutine(MovePositionLimitCo());
    }
    void StopMove()
    {
        rigidbody.velocity = Vector2.zero;
        StopCoroutine(MovePositionLimitCo());
    }
    IEnumerator MovePositionLimitCo()
    {
        while (true)
        {
            transform.position = Viewport.Instance.PlayerMovablePosition(transform.position,paddingX,paddingY);
            yield return null;
        }
    }
}
