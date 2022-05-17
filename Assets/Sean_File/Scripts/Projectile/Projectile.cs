using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]protected float moveSpeed = 10f;
        [SerializeField]protected Vector2 moveDirection;

        IEnumerator MoveDirectlyCo()
        {
            while (gameObject.activeSelf)
            {
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        protected virtual void OnEnable()
        {
            StartCoroutine(MoveDirectlyCo());
        }
    }
}