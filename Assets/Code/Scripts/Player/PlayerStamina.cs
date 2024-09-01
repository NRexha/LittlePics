using System;
using UnityEngine;

namespace Player
{
    public class PlayerStamina : MonoBehaviour
    {
        private const float MAX_STAMINA = 100f;
        [SerializeField] private float _regenerationRate = 5f;
        [SerializeField] private float _consumeRate = 10f;

        public static event Action<float> OnStaminaChanged;

        private float _currentStamina;
        private bool _isSprinting;

        public float StaminaNormalized => _currentStamina / MAX_STAMINA;

        private void Awake()
        {
            _currentStamina = MAX_STAMINA;
        }

        private void OnEnable()
        {
            PlayerSprint.OnSprintChanged += OnSprintStateChanged;
        }

        private void OnDisable()
        {
            PlayerSprint.OnSprintChanged -= OnSprintStateChanged;
        }

        private void Update()
        {
            if (_isSprinting)
            {
                ConsumeStamina();
            }
            else
            {
                RegenerateStamina();
            }
            OnStaminaChanged?.Invoke(StaminaNormalized);
        }

        private void OnSprintStateChanged(bool isSprinting, float value)
        {
            _isSprinting = isSprinting;
        }

        private void ConsumeStamina()
        {
            if (_currentStamina > 0)
            {
                _currentStamina -= _consumeRate * Time.deltaTime;
                _currentStamina = Mathf.Max(_currentStamina, 0);
            }
        }

        private void RegenerateStamina()
        {
            if (_currentStamina < MAX_STAMINA)
            {
                _currentStamina += _regenerationRate * Time.deltaTime;
                _currentStamina = Mathf.Min(_currentStamina, MAX_STAMINA);
            }
        }
    }
}
