using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private float _originalY;
   

        private void Start()
        {
            _originalY = transform.localScale.y;
        }
        private void LateUpdate()
        {
            transform.position =  new Vector3(_target.position.x, _originalY, _target.position.z);
        }
    }
}
