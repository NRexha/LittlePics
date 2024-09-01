using General;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region VARIABLES
        [Header("Movement Params")]
        [SerializeField] private float _movementSpeed = 5f;
        [SerializeField] private float _sprintTransitionTime = 5f;

        private Vector2 _movementInput;
        private float _currentSpeed;
        private float _targetSpeed;

        [Header("References")]
        [SerializeField] private CharacterController _characterController;
        private Camera _camera;
        private PlayerInputs _playerInputs;
        #endregion

        #region EVENTS
        public static event Action<float> OnVelocityChanged;
        public static event Action<bool> OnMovementStatusChanged;
        #endregion

        #region PROPERTIES
        public float MovementSpeed { get => _movementSpeed; set => _ = _movementSpeed; }
        public Vector2 MovementInput { get => _movementInput; set => _ = _movementInput; } 
        #endregion

        #region INITIALIZE
        private void Awake()
        {
            _playerInputs = new PlayerInputs();
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _playerInputs.InGame.Enable();
            _playerInputs.InGame.Move.performed += OnMove;
            _playerInputs.InGame.Move.canceled += OnMove;
        }

        private void OnDisable()
        {
            _playerInputs.InGame.Disable();
            _playerInputs.InGame.Move.performed -= OnMove;
            _playerInputs.InGame.Move.canceled -= OnMove;
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
            _movementInput = context.ReadValue<Vector2>();

            bool isMoving = _movementInput.magnitude > 0.1f;
            OnMovementStatusChanged?.Invoke(isMoving);
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
            float normalizedVelocity = Mathf.Clamp01(_movementInput.magnitude);
            OnVelocityChanged?.Invoke(normalizedVelocity);
        }

        public void SetSpeed(float speed)
        {
            _targetSpeed = speed;
        } 
        #endregion
    }
}
