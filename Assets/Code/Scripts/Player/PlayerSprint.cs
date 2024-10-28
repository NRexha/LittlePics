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
        private bool _sprintInput;
        private bool _hasStamina = true;
        private bool _isShooting = false; 

        [Header("References")]
        private PlayerMovement _playerMovement;
        private PlayerInputs _playerInputs;

        public static event Action<bool, float> OnSprintChanged;

        private void Awake()
        {
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
            _playerMovement = PlayerComponents.Instance.PlayerMovementScript;
        }

        private void OnEnable()
        {
            _playerInputs.InGame.Sprint.performed += OnSprint;
            _playerInputs.InGame.Sprint.canceled += OnSprint;

            PlayerMovement.OnMovementStatusChanged += OnMovementStatusChanged;
            PlayerStamina.OnStaminaChanged += UpdateStaminaStatus;
            PlayerShooting.OnShootChanged += OnShootChanged;
        }

        private void OnDisable()
        {
            _playerInputs.InGame.Sprint.performed -= OnSprint;
            _playerInputs.InGame.Sprint.canceled -= OnSprint;

            PlayerMovement.OnMovementStatusChanged -= OnMovementStatusChanged;
            PlayerStamina.OnStaminaChanged -= UpdateStaminaStatus;
            PlayerShooting.OnShootChanged -= OnShootChanged;
        }

        private void UpdateStaminaStatus(float staminaNormalized)
        {
            _hasStamina = staminaNormalized > 0;
            if (!_hasStamina)
            {
                StopSprinting();
            }
        }

        private void StopSprinting()
        {
            _sprintInput = false;
            _playerMovement.SetSpeed(_playerMovement.MovementSpeed);
            OnSprintChanged?.Invoke(false, 1f);
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
            bool isMoving = _playerMovement.MovementInput.magnitude > 0.1f;

            if (_sprintInput && isMoving && _hasStamina && !_isShooting)  
            {
                _playerMovement.SetSpeed(_sprintSpeed);
                float sprintMultiplier = _sprintSpeed / _playerMovement.MovementSpeed;
                OnSprintChanged?.Invoke(true, sprintMultiplier);
            }
            else
            {
                StopSprinting();
            }
        }

        private void OnMovementStatusChanged(bool isMoving)
        {
            if (!isMoving)
            {
                StopSprinting();
            }
        }

        private void OnShootChanged(bool isShooting)
        {
            _isShooting = isShooting;  
            if (_isShooting)
            {
                StopSprinting();  
            }
        }
    }
}
