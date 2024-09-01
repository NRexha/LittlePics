using System;
using UnityEngine;
using UnityEngine.Animations;

namespace Player
{
    public class PlayerMovementVisuals : MonoBehaviour
    {
        [Header("Movement Params")]
        [SerializeField][Range(0f, 1f)] private float _dampTime;
        private float _sprintMultiplier = 1f;

        [Header("References")]
        [SerializeField] private Animator _animator;
        [SerializeField] private string _movementTreeParameter = "Movement";
        [SerializeField] private string _sprintParameter = "Sprint";

        private void OnEnable()
        {
            PlayerMovement.OnVelocityChanged += UpdateVelocityParameter;
            PlayerSprint.OnSprintChanged += UpdateSprintParameter; 
        }

        private void OnDisable()
        {
            PlayerMovement.OnVelocityChanged -= UpdateVelocityParameter;
            PlayerSprint.OnSprintChanged -= UpdateSprintParameter; 
        }

        private void UpdateVelocityParameter(float velocity)
        {
            float adjustedVelocity = velocity * _sprintMultiplier;
            _animator.SetFloat(_movementTreeParameter, adjustedVelocity, _dampTime, Time.deltaTime);
        }

        private void UpdateSprintParameter(bool isSprinting, float sprintMultiplier)
        {
            _sprintMultiplier = sprintMultiplier;
            _animator.SetBool(_sprintParameter, isSprinting);
        }
    }
}
