using General;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerPunch : MonoBehaviour
    {
        [SerializeField] private float _comboWindowTime = 1f;

        private float _lastAttackTime = 0f;
        private int _comboStep = 0;

        private PlayerInputs _playerInputs;

        public static event System.Action<int> OnComboStepChanged;

        private void Awake()
        {
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
        }

        private void OnEnable()
        {
            _playerInputs.InGame.Melee.performed += OnMelee;
        }

        private void OnDisable()
        {
            _playerInputs.InGame.Melee.performed -= OnMelee;
        }

        private void OnMelee(InputAction.CallbackContext context)
        {
            if (Time.time - _lastAttackTime <= _comboWindowTime)
            {
                _comboStep++;
            }
            else
            {
                _comboStep = 1;
            }

            _lastAttackTime = Time.time;
            OnComboStepChanged?.Invoke(_comboStep);

            
            
        }

        
    }
}
