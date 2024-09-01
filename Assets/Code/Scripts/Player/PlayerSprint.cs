using General;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerSprint : MonoBehaviour
    {
        [Header("Sprint Params")]
        [SerializeField] private float _sprintSpeed = 10f;
        [SerializeField] private float _minSprintSpeed = 2f;
        private bool _sprintInput;

        [Header("References")]
        [SerializeField] private PlayerMovement _playerMovement;

        private PlayerInputs _playerInputs;

        public static event Action<bool, float> OnSprintChanged;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();
        }

        private void OnEnable()
        {
            _playerInputs.InGame.Enable();
            _playerInputs.InGame.Sprint.performed += OnSprint;
            _playerInputs.InGame.Sprint.canceled += OnSprint;

            PlayerMovement.OnMovementStatusChanged += OnMovementStatusChanged;
        }

        private void OnDisable()
        {
            _playerInputs.InGame.Disable();
            _playerInputs.InGame.Sprint.performed -= OnSprint;
            _playerInputs.InGame.Sprint.canceled -= OnSprint;

            PlayerMovement.OnMovementStatusChanged -= OnMovementStatusChanged;
        }

        private void Update()
        {
            HandleSprintLogic();
        }

        private void OnSprint(InputAction.CallbackContext context)
        {
            _sprintInput = context.ReadValue<float>() > 0;
        }

        private void HandleSprintLogic()
        {
       
            if (_sprintInput && _playerMovement.MovementInput.magnitude > 0.1f)
            {
                float sprintMultiplier = _sprintSpeed / _playerMovement.MovementSpeed;
                OnSprintChanged?.Invoke(true, sprintMultiplier);
            }
            else
            {
                OnSprintChanged?.Invoke(false, 1f);
            }
        }

        private void OnMovementStatusChanged(bool isMoving)
        {
            if (!isMoving)
            {
                _sprintInput = false;
                OnSprintChanged?.Invoke(false,1f);
            }
        }
    }
}
