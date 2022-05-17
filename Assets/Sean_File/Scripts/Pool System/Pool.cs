using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    [System.Serializable]
    public class Pool 
    {
        public GameObject Prefab { get => prefab; }
        public int Size { get => size; }
        public int RuntimeSize { get => queue.Count; }
        [SerializeField] GameObject prefab;
        [SerializeField] int size = 1; 
        Queue<GameObject> queue;
        Transform parent;
        public void Initialize(Transform _parent)
        {
            this.parent = _parent;
            queue = new Queue<GameObject>();
            for (int  i = 0;  i < size;  i++)
            {
                queue.Enqueue(Copy());
            }
        }

        GameObject Copy()
        {
            var _copy = GameObject.Instantiate(prefab,parent);

            _copy.SetActive(false);

            return _copy;
        }
        GameObject AvailableObject()
        {
            GameObject _availableObj = null;
            if (queue.Count > 0 && !queue.Peek().activeSelf)
            {
                _availableObj = queue.Dequeue();
            }
            else
            {
                _availableObj = Copy();
            }
            queue.Enqueue(_availableObj);
            return _availableObj;
        }
        #region -- PreparedObject ¤Î¨ä­«¸ü --
        public GameObject PreparedObject()
        {
            GameObject _preparedObj = AvailableObject();
            _preparedObj.SetActive(true);
            return _preparedObj;
        }
        public GameObject PreparedObject(Vector3 _position)
        {
            GameObject _preparedObj = AvailableObject();
            _preparedObj.SetActive(true);
            _preparedObj.transform.position = _position;
            return _preparedObj;
        }
        public GameObject PreparedObject(Vector3 _position,Quaternion _rotation)
        {
            GameObject _preparedObj = AvailableObject();
            _preparedObj.SetActive(true);
            _preparedObj.transform.position = _position;
            _preparedObj.transform.rotation = _rotation;
            return _preparedObj;
        }
        public GameObject PreparedObject(Vector3 _position, Quaternion _rotation,Vector3 _localScale)
        {
            GameObject _preparedObj = AvailableObject();
            _preparedObj.SetActive(true);
            _preparedObj.transform.position = _position;
            _preparedObj.transform.rotation = _rotation;
            _preparedObj.transform.localScale = _localScale;
            return _preparedObj;
        }
        #endregion
    }
}