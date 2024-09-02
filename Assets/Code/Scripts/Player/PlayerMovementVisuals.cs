using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovementVisuals : MonoBehaviour
    {
        [Header("Movement Params")]
        [SerializeField][Range(0f, 1f)] private float _dampTime;
        [SerializeField] private float _shootingVelocityClamp = 0.5f;  
        private float _sprintMultiplier = 1f;
        private bool _isShooting = false; 

        [Header("References")]
        private Animator _animator;
        [SerializeField] private string _movementTreeParameter = "Movement";
        [SerializeField] private string _sprintParameter = "Sprint";

        private void Awake()
        {
            _animator = PlayerComponents.Instance.Animator;
        }

        private void OnEnable()
        {
            PlayerMovement.OnVelocityChanged += UpdateVelocityParameter;
            PlayerSprint.OnSprintChanged += UpdateSprintParameter;
            PlayerShooting.OnShootChanged += ReduceVelocity;
        }

        private void OnDisable()
        {
            PlayerMovement.OnVelocityChanged -= UpdateVelocityParameter;
            PlayerSprint.OnSprintChanged -= UpdateSprintParameter;
            PlayerShooting.OnShootChanged -= ReduceVelocity;
        }

        private void UpdateVelocityParameter(float velocity)
        {

            float adjustedVelocity = _isShooting ? Mathf.Clamp(velocity, 0, _shootingVelocityClamp) : velocity * _sprintMultiplier;
            _animator.SetFloat(_movementTreeParameter, adjustedVelocity, _dampTime, Time.deltaTime);
        }

        private void UpdateSprintParameter(bool isSprinting, float sprintMultiplier)
        {
            _sprintMultiplier = sprintMultiplier;
            _animator.SetBool(_sprintParameter, isSprinting);
        }

        private void ReduceVelocity(bool isShooting)
        {
            _isShooting = isShooting;  
        }
    }
}
