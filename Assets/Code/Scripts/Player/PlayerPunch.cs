using General;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerPunch : MonoBehaviour
    {
        #region VARIABLES
        [Header("Combo Params")]
        [SerializeField] private float _comboWindowTime = 1f;
        [SerializeField] private int _punchLayerIndex = 2;
        private float _lastAttackTime = 0f;
        private int _comboStep = 0;
        private Vector3 _fixedPosition;

        [Header("References")]
        [SerializeField] private string _idleCombatState = "IdleCombat";
        private PlayerInputs _playerInputs;
        private Animator _animator;
        #endregion

        public static event System.Action<int> OnComboStepChanged;

        private void Awake()
        {
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
            _animator = PlayerComponents.Instance.Animator;
        }

        private void OnEnable()
        {
            _playerInputs.InGame.TriggerActiveObject.performed += OnMelee;
        }

        private void OnDisable()
        {
            _playerInputs.InGame.TriggerActiveObject.performed -= OnMelee;
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

        private void Update()
        {
            //kinda trash for the momement i know
            if (!_animator.GetCurrentAnimatorStateInfo(_punchLayerIndex).IsName(_idleCombatState))
            {
                DisableMovement();
            }
            if (_animator.GetCurrentAnimatorStateInfo(_punchLayerIndex).IsName(_idleCombatState))
            {
                EnableMovement();
            }
            else
            {
                transform.position = _fixedPosition;
            }
        }

        private void DisableMovement()
        {

            _fixedPosition = transform.position;
            _playerInputs.InGame.Move.Disable();

        }

        private void EnableMovement()
        {

            _playerInputs.InGame.Move.Enable();

        }
    }
}
