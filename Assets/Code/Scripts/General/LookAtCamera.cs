using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    public class LookAtCamera : MonoBehaviour
    {
        #region VARIABLES
        private Camera _camera;
        #endregion

        #region INITIALIZE
        private void Awake()
        {
            _camera = Camera.main;
        } 
        #endregion
        private void LateUpdate()
        {
            LookCamera();
        }
        #region LOOK_CAMERA
        private void LookCamera()
        {
            transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
        } 
        #endregion
    }
}
