using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 10f;
        [SerializeField] Vector2 moveDirection;

        IEnumerator MoveDirectlyCo()
        {
            while (gameObject.activeSelf)
            {
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        private void OnEnable()
        {
            StartCoroutine(MoveDirectlyCo());
        }
    }
}