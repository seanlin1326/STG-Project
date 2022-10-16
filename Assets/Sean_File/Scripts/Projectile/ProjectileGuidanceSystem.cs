using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class ProjectileGuidanceSystem : MonoBehaviour
    {
        [SerializeField] Projectile projectile;
        [SerializeField] float minBallisticAngle = 50f;
        [SerializeField] float maxBallisticAngle = 75f;
        float ballisitcAngle;
        Vector3 targetDirection;
      public IEnumerator HomingCoroutine(GameObject target)
        {
            ballisitcAngle = Random.Range(minBallisticAngle,maxBallisticAngle);
            while (gameObject.activeSelf)
            {
                if (target.activeSelf)
                {
                    //move to target
                    targetDirection = target.transform.position - transform.position;

                    // rotate to target
                    var angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.rotation *= Quaternion.Euler(0f,0f,ballisitcAngle);

                    //move projectile
                    projectile.Move();
                }
                else
                {
                    //move projectile in move direction
                    projectile.Move();
                }
                yield return null;
            }

        }
    }
}