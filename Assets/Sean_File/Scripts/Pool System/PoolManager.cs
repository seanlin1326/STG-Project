using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] List<Pool> playerProjectilePools=new List<Pool>();
        [SerializeField] List<Pool> enemyProjectilePools = new List<Pool>();
      static Dictionary<GameObject, Pool> dictionary;
        // Start is called before the first frame update
        void Start()
        {
         
            dictionary = new Dictionary<GameObject, Pool>();
            Initialize(playerProjectilePools);
            Initialize(enemyProjectilePools);
        }
        private void OnDestroy()
        {
         #if UNITY_EDITOR
            CheckPoolSize(playerProjectilePools);
            CheckPoolSize(enemyProjectilePools);
         #endif
        }
        void CheckPoolSize(List<Pool> _pools)
        {
            foreach (var _pool in _pools)
            {
                if(_pool.RuntimeSize > _pool.Size)
                {
                    Debug.LogWarning(
                         string.Format("Pool:{0} has a runtime size {1} bigger than its initial size {2}!",
                         _pool.Prefab.name,
                         _pool.RuntimeSize,
                         _pool.Size));
                }
            }
        }
        void Initialize(List<Pool> _pools)
        {
            foreach (var _pool in  _pools)
            {

                if (dictionary.ContainsKey(_pool.Prefab))
                {
                    Debug.LogError("Same prefab in multiple pool! "+_pool.Prefab.name);
                    continue;
                }
                dictionary.Add(_pool.Prefab, _pool);
             Transform _poolParent = new GameObject("Pool: " + _pool.Prefab.name).transform;
                _poolParent.parent = transform;
                _pool.Initialize(_poolParent);
            }
        }
#region -- Release 及相關參數 --
        /// <summary>
        /// 根據傳入的<paramref name="_prefab"/>參數返回對象池中準備好的對應遊戲對象
        /// </summary>

        /// <returns></returns>
        public static GameObject Release(GameObject _prefab)
        {
            if (!dictionary.ContainsKey(_prefab))
            {
                Debug.LogError("Pool Manager could not find prefab :" + _prefab.name);
                return null;
            }

            return dictionary[_prefab].PreparedObject();

        }
        /// <summary>
        /// 根據傳入的<paramref name="_prefab"/>參數返回對象池中準備好的對應遊戲對象
        /// </summary>
        /// <returns></returns>
        public static GameObject Release(GameObject _prefab,Vector3 _position)
        {
            if (!dictionary.ContainsKey(_prefab))
            {
                Debug.LogError("Pool Manager could not find prefab :" + _prefab.name);
                return null;
            }

            return dictionary[_prefab].PreparedObject(_position);

        }
        /// <summary>
        /// 根據傳入的<paramref name="_prefab"/>參數返回對象池中準備好的對應遊戲對象
        /// </summary>
     
        /// <returns></returns>
        public static GameObject Release(GameObject _prefab, Vector3 _position,Quaternion _rotation)
        {
            if (!dictionary.ContainsKey(_prefab))
            {
                Debug.LogError("Pool Manager could not find prefab :" + _prefab.name);
                return null;
            }

            return dictionary[_prefab].PreparedObject(_position,_rotation);

        }
        /// <summary>
        /// 根據傳入的<paramref name="_prefab"/>參數返回對象池中準備好的對應遊戲對象
        /// </summary>
        
        /// <returns></returns>
        public static GameObject Release(GameObject _prefab, Vector3 _position, Quaternion _rotation,Vector3 _localScale)
        {
            if (!dictionary.ContainsKey(_prefab))
            {
                Debug.LogError("Pool Manager could not find prefab :" + _prefab.name);
                return null;
            }
           
            return dictionary[_prefab].PreparedObject(_position, _rotation,_localScale);
            
        }
#endregion
    }
}