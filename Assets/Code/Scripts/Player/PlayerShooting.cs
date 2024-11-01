using Enemy;
using General;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        #region VARIABLES
        [Header("Shooting Params")]
        [SerializeField] private float _gunAppearDelay = 1f;
        [SerializeField] private float _shootDistance = 10f;
        [SerializeField] private float _laserDuration = 0.5f;
        [SerializeField] private float _damageAmount = 10f;
        private bool _isLaserActive = false;
        private Vector3 _laserStartPoint;
        private Vector3 _laserEndPoint;

        [Header("References")]
        [SerializeField] private GameObject _gun;
        [SerializeField] private Transform _shootOrigin;
        private PlayerInputs _playerInputs; 
        #endregion


        public static event Action<bool> OnShootChanged;

        private void Awake()
        {
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
        }

        private void OnEnable()
        {
            _playerInputs.InGame.TriggerActiveObject.performed += OnShoot;
            _playerInputs.InGame.TriggerActiveObject.canceled += OnShoot;
            StartCoroutine(SwitchGunAfterDelay(true, _gunAppearDelay));
        }

        private void OnDisable()
        {
            _playerInputs.InGame.TriggerActiveObject.performed -= OnShoot;
            _playerInputs.InGame.TriggerActiveObject.canceled -= OnShoot;
            StartCoroutine(SwitchGunAfterDelay(false, _gunAppearDelay));
        }

        private void OnShoot(InputAction.CallbackContext context)
        {
            bool isShooting = context.ReadValue<float>() > 0;
            OnShootChanged?.Invoke(isShooting);

            
        }

        private IEnumerator SwitchGunAfterDelay(bool trigger, float delay)
        {
            yield return new WaitForSeconds(delay);
            _gun.SetActive(trigger);
        }

        public void ShootLaser()
        {
            if (_shootOrigin != null)
            {
                RaycastHit hit;
                Vector3 shootDirection = _shootOrigin.forward;
                _laserStartPoint = _shootOrigin.position;
                _laserEndPoint = _shootOrigin.position + shootDirection * _shootDistance;

                _isLaserActive = true;

                if (Physics.Raycast(_laserStartPoint, shootDirection, out hit, _shootDistance))
                {
                    _laserEndPoint = hit.point;
                    if (hit.collider.TryGetComponent(out IEnemyHealth enemy))
                    {
                        Vector3 impulseDirection = hit.point - _shootOrigin.position;
                        impulseDirection.Normalize();
                        enemy.TakeDamage(_damageAmount, impulseDirection);
                    }
                }

                StartCoroutine(DisableLaserAfterDuration(_laserDuration));
            }
        }

        private IEnumerator DisableLaserAfterDuration(float duration)
        {
            yield return new WaitForSeconds(duration);
            _isLaserActive = false;
        }

        private void OnDrawGizmos()
        {
            if (_isLaserActive)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(_laserStartPoint, _laserEndPoint);
            }
        }
    }
}
