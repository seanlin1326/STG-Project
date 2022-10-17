using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class EnemyController : MonoBehaviour
    {
        [Header("----- Move -----")]
        [SerializeField] float paddingX;
        [SerializeField] float paddingY;
        [SerializeField] float moveSpeed=2f;
        [SerializeField] float moveRotationAngle = 25f;

       [Header("----- Fire -----")]
       [SerializeField] List<GameObject> projectiles;
       [SerializeField] AudioData[] projectileLaunchSFX;
       [SerializeField] Transform muzzle;
      

      [SerializeField] float minFireInterval=1;
      [SerializeField] float maxFireInterval=3;


        private void OnEnable()
        {

            StartCoroutine(nameof(RandomlyMovingCoroutine));
            StartCoroutine(nameof(RandomlyFireCoroutine));
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        IEnumerator RandomlyMovingCoroutine()
        {
            yield return null;
            transform.position=Viewport.Instance.RandomEnemySpawnPosition(paddingX, paddingY);
            Vector3 _targetPosition = Viewport.Instance.RandomRightHalfPosition(paddingX, paddingY);

            while (gameObject.activeSelf)
            {
                //if has not arrived targetPosition
                if (Vector3.Distance(transform.position, _targetPosition) >= moveSpeed * Time.fixedDeltaTime)
                {
                    //keep moving to targetPosition
                    transform.position = Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.fixedDeltaTime);
                    transform.rotation = Quaternion.AngleAxis((_targetPosition - transform.position).normalized.y * moveRotationAngle, Vector3.right);
                }
                else
                {
                    //set a new target
                    _targetPosition = Viewport.Instance.RandomRightHalfPosition(paddingX, paddingY);
                }
                yield return new WaitForFixedUpdate();
            }
        }

        IEnumerator RandomlyFireCoroutine()
        {
            while (gameObject.activeSelf)
            {
                yield return new WaitForSeconds(Random.Range(minFireInterval,maxFireInterval));
                foreach (var _projectile in projectiles)
                {
                    PoolManager.Release(_projectile, muzzle.position);
                }
                AudioManager.Instance.PlayRandomSFX(projectileLaunchSFX);
            }
        }
        }
}