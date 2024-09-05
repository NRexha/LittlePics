using General;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerPunch : MonoBehaviour
    {
        [SerializeField] private float _comboWindowTime = 1f;
        [SerializeField] private int _punchLayerIndex = 2;
        [SerializeField] private string _idleCombatState = "IdleCombat";


        private float _lastAttackTime = 0f;
        private int _comboStep = 0;
        private Vector3 _fixedPosition;

        private PlayerInputs _playerInputs;
        private Animator _animator;
        private CharacterController _characterController;

        public static event System.Action<int> OnComboStepChanged;

        private void Awake()
        {
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
            _animator = PlayerComponents.Instance.Animator;
            _characterController = PlayerComponents.Instance.CharacterController;
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

            if (!_animator.GetCurrentAnimatorStateInfo(_punchLayerIndex).IsName(_idleCombatState))
            {
                DisableMovement();
            }
        }

        private void Update()
        {
            if (_animator.GetCurrentAnimatorStateInfo(_punchLayerIndex).IsName(_idleCombatState))
            {
                EnableMovement();
            }
            else
            {
                if (!_characterController.enabled)
                {
                    transform.position = _fixedPosition;
                }
            }
        }

        private void DisableMovement()
        {
            if (_characterController.enabled)
            {
                _fixedPosition = transform.position;
                _characterController.enabled = false;
            }
        }

        private void EnableMovement()
        {
            if (!_characterController.enabled)
            {
                _characterController.enabled = true;
            }
        }
    }
}
