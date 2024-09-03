using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CameraRelated
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("General Parameters")]
        [SerializeField] private Vector3 _initialRotation;
        [SerializeField] private float _initalHeight = 40f;

        [Header("Follow Parameters")]
        [SerializeField] private float _cameraSpeed = 2.5f;
        [SerializeField] private float _xDistance = 2f;
        private Vector3 _offset;
        private Vector3 _velocity = Vector3.zero;

        [Header("Zoom Parameters")]
        [SerializeField] private float _zoomOutDistance = 4f;

        [Header("References")]
        [SerializeField] private Transform _playerTransform;
        private Transform _currentTarget;

        
        private void Start()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(_initialRotation);

            transform.position = new Vector3(_playerTransform.position.x, _initalHeight, _playerTransform.position.z);
            _offset = transform.position - _playerTransform.position;

            _currentTarget = _playerTransform;
        }

        private void LateUpdate()
        {
            Zoom();
            Follow();
        }


        private void Zoom()
        {
            Vector3 targetPosition = _currentTarget.position;
            targetPosition.x += _xDistance;
            Vector3 zoomPosition = targetPosition + _offset * _zoomOutDistance;
            transform.position = Vector3.Lerp(transform.position, zoomPosition, Time.deltaTime * _cameraSpeed);
        }

        private void Follow()
        {
            Vector3 targetPosition = _currentTarget.position;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _cameraSpeed);
        }

        

        

    }
}
