using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeactivate : MonoBehaviour
{
    [SerializeField] bool destroyGameObj;
    [SerializeField] float lifeTime=3f;
    private void OnEnable()
    {
        StartCoroutine(DeactivateCo());      
    }
 
    IEnumerator DeactivateCo()
    {
        yield return new WaitForSeconds(lifeTime);
        if (destroyGameObj)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
