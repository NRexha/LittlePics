using General;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region VARIABLES
        [Header("Movement Params")]
        [SerializeField] private float _movementSpeed = 5f;
        [SerializeField] private float _sprintSpeed = 10f;
        [SerializeField] private float _sprintTransitionTime = 5f;

        private Vector2 _movementInput;
        private float _currentSpeed;
        private float _targetSpeed;
        private float _sprintInput;

        [Header("References")]
        private Camera _camera;
        private CharacterController _characterController;
        private PlayerInputs _playerInputs;
        #endregion

        #region EVENTS
        public static event Action<float> OnVelocityChanged;
        public static event Action<bool> OnSprintChanged; 
        #endregion

        #region INITIALIZE_COMPONENTS
        private void Awake()
        {
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
            _characterController = PlayerComponents.Instance.CharacterController;
            _camera = PlayerComponents.Instance.Camera;
        }
        #endregion

        #region EVENTS_SUBSCRIBE
        private void OnEnable()
        {
            _playerInputs.InGame.Enable();
            _playerInputs.InGame.Move.performed += OnMove;
            _playerInputs.InGame.Move.canceled += OnMove;
            _playerInputs.InGame.Sprint.performed += OnSprint;
            _playerInputs.InGame.Sprint.canceled += OnSprint;
        }

        private void OnDisable()
        {
            _playerInputs.InGame.Disable();
            _playerInputs.InGame.Move.performed -= OnMove;
            _playerInputs.InGame.Move.canceled -= OnMove;
            _playerInputs.InGame.Sprint.performed -= OnSprint;
            _playerInputs.InGame.Sprint.canceled -= OnSprint;
        } 
        #endregion
        private void Start()
        {
            _targetSpeed = _movementSpeed;
            
        }
        private void Update()
        {
            PlayerMove();
        }

        #region MOVEMENT
        private void OnMove(InputAction.CallbackContext context)
        {
            _movementInput = context.ReadValue<Vector2>();
        }
        private void PlayerMove()
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, _targetSpeed, Time.deltaTime * _sprintTransitionTime);

            Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 cameraRight = _camera.transform.right;
            Vector3 moveDirection = _movementInput.x * cameraRight + _movementInput.y * cameraForward;

            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.1f);
            }

            _characterController.SimpleMove(moveDirection * _currentSpeed);
            UpdateMagnitude();
        }

        private void UpdateMagnitude()
        {
            float velocity = _movementInput.magnitude * _currentSpeed;
            float normalizedVelocity = Mathf.Clamp01(velocity);

            OnVelocityChanged?.Invoke(normalizedVelocity);
        }
        #endregion

        #region SPRINT
        private void OnSprint(InputAction.CallbackContext context)
        {
            _sprintInput = context.ReadValue<float>();
            PlayerSprint();
        }
        private void PlayerSprint()
        {
            _targetSpeed = _sprintInput > 0 ? _sprintSpeed : _movementSpeed;

            OnSprintChanged?.Invoke(_sprintInput > 0);
        } 
        #endregion

    }
}
