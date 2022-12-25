using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] Vector2 scrollVelocity;
        Material material;
        private void Awake()
        {
            material = GetComponent<Renderer>().material;
        }
        // Start is called before the first frame update
      

        // Update is called once per frame
        void Update()
        {
            if (GameManager.CurrentGameState == GameState.Playing)
            {
                material.mainTextureOffset += scrollVelocity * Time.deltaTime;
            }
        }
    }
}