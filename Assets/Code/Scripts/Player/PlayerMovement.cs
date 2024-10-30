using System;
using UnityEngine;
using UnityEngine.InputSystem;
using General;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region VARIABLES
        [Header("Movement Params")]
        [SerializeField] private float _movementSpeed = 5f;
        [SerializeField] private float _sprintTransitionTime = 5f;
        [SerializeField] private float _shootingSpeedClamp = 2f;

        private Vector2 _movementInput;
        private float _currentSpeed;
        private float _targetSpeed;
        private bool _isSprinting = false;
        private bool _isShooting = false;
        private float _sprintMultiplier;

        [Header("References")]
        private CharacterController _characterController;
        private Camera _camera;
        private PlayerInputs _playerInputs;
        #endregion

        #region EVENTS
        public static event Action<float> OnVelocityChanged;
        public static event Action<bool> OnMovementStatusChanged;
        #endregion

        #region PROPERTIES
        public float MovementSpeed => _movementSpeed;
        public Vector2 MovementInput => _movementInput;
        #endregion

        #region INITIALIZE
        private void Awake()
        {
            _camera = Camera.main;
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
        }

        private void OnEnable()
        {
            _playerInputs.InGame.Move.performed += OnMove;
            _playerInputs.InGame.Move.canceled += OnMove;
            PlayerSprint.OnSprintChanged += HandleSprintState;
            PlayerShooting.OnShootChanged += HandleShootState;
            _characterController = PlayerComponents.Instance.CharacterController;
        }

        private void OnDisable()
        {
            _playerInputs.InGame.Move.performed -= OnMove;
            _playerInputs.InGame.Move.canceled -= OnMove;
            PlayerSprint.OnSprintChanged -= HandleSprintState;
            PlayerShooting.OnShootChanged -= HandleShootState;
        }

        private void Start()
        {
            _targetSpeed = _movementSpeed;
        }
        #endregion

        private void Update()
        {


            PlayerMove();


        }

        #region MOVEMENT
        private void OnMove(InputAction.CallbackContext context)
        {
            if (Time.timeScale == 1)
            {
                _movementInput = context.ReadValue<Vector2>();
                bool isMoving = _movementInput.magnitude > 0.1f;
                OnMovementStatusChanged?.Invoke(isMoving); 
            }
        }

        private void PlayerMove()
        {

            if (_isShooting)
            {
                _targetSpeed = _shootingSpeedClamp;
            }
            else if (_isSprinting)
            {
                _targetSpeed = _movementSpeed * _sprintMultiplier;
            }
            else
            {
                _targetSpeed = _movementSpeed;
            }

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
            float normalizedVelocity = Mathf.Clamp01(_movementInput.magnitude);

            OnVelocityChanged?.Invoke(normalizedVelocity);


        }

        public void SetSpeed(float speed)
        {
            _targetSpeed = speed;
        }

        private void HandleSprintState(bool isSprinting, float sprintMultiplier)
        {
            _isSprinting = isSprinting;
            _sprintMultiplier = sprintMultiplier;

            if (!_isShooting)
            {
                _targetSpeed = _movementSpeed * _sprintMultiplier;
            }
        }

        private void HandleShootState(bool isShooting)
        {
            _isShooting = isShooting;
            if (isShooting)
            {

                _targetSpeed = _shootingSpeedClamp;
            }
        }
        #endregion
    }
}
