using Enemy;
using General;
using System.Collections;
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
        [SerializeField] private float _damage = 5f;
        [SerializeField] private float _increaseDamageRate = 1f;
        [SerializeField] private float _impactDuration = 0.1f;
        [SerializeField] private float _impactTimeScale = 0.1f;
        private float _lastAttackTime = 0f;
        private int _comboStep = 0;
        private Vector3 _fixedPosition;
        private int _activeCollider;
        private float _originalDamage;

        [Header("References")]
        [SerializeField] private string _idleCombatState = "IdleCombat";
        [SerializeField] private Collider[] _colliders; 
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
        private void Start()
        {
            _originalDamage = _damage;
        }

        private void OnMelee(InputAction.CallbackContext context)
        {
            if (Time.time - _lastAttackTime <= _comboWindowTime)
            {

                _comboStep++;
                _damage += _increaseDamageRate;

            }
            else
            {
                _comboStep = 1;
                _damage = _originalDamage;
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
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IEnemyHealth enemy))
            {
                enemy.TakeDamage(_damage, transform.forward);
                Quaternion.LookRotation(other.transform.position, transform.up);
                StartCoroutine(ImpactFramesCoroutine(_damage));
            }
        }

        private IEnumerator ImpactFramesCoroutine(float multiplier)
        {
            float originalTimeScale = Time.timeScale;

            Time.timeScale = _impactTimeScale;
            yield return new WaitForSecondsRealtime(_impactDuration * multiplier);
            Time.timeScale = originalTimeScale;
        }
        public void ActivateCollider(int scheme)
        {
            _colliders[scheme].enabled = true;
            _activeCollider = scheme;
        }
        public void DisableAllColliders()
        {
            foreach(Collider collider in _colliders)
            {
                collider.enabled = false;
            }
        }
    }
}