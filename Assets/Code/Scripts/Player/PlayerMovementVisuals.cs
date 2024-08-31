using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMovementVisuals : MonoBehaviour
    {
        #region VARIABLES
        [Header("Movement Params")]
        [SerializeField][Range(0f, 1f)] private float _dampTime;

        [Header("References")]
        [SerializeField] private string _movementTreeParameter = "Movement";
        [SerializeField] private string _sprintParameter = "Sprint";
        private Animator _animator;
        #endregion


        #region EVENTES_SUBSCRIBE
        private void OnEnable()
        {
            PlayerMovement.OnVelocityChanged += UpdateVelocityParameter;
            PlayerMovement.OnSprintChanged += UpdateSprintParameter;
        }
        private void OnDisable()
        {
            PlayerMovement.OnVelocityChanged -= UpdateVelocityParameter;
            PlayerMovement.OnSprintChanged -= UpdateSprintParameter;
        } 
        #endregion

        private void Start()
        {
            _animator = PlayerComponents.Instance.Animator;
        }

        #region MOVEMENT
        private void UpdateVelocityParameter(float velocity)
        {
            _animator.SetFloat(_movementTreeParameter, velocity, _dampTime, Time.deltaTime);
        }
        #endregion

        #region SPRINT
        private void UpdateSprintParameter(bool isSprinting)
        {
            _animator.SetBool(_sprintParameter, isSprinting);
        } 
        #endregion
    }
}
