using General;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private GameObject _gun;
        [SerializeField] private float _gunAppearDelay = 1f;
        private PlayerInputs _playerInputs;

 
        public static event Action<bool> OnShootChanged;

        private void Awake()
        {
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
        }

        private void OnEnable()
        {
            _playerInputs.InGame.Shoot.performed += OnShoot;
            _playerInputs.InGame.Shoot.canceled += OnShoot;
            StartCoroutine(ActivateGunAfterDelay(_gunAppearDelay));
        }

        private void OnDisable()
        {
            _playerInputs.InGame.Shoot.performed -= OnShoot;
            _playerInputs.InGame.Shoot.canceled -= OnShoot;
            _gun.SetActive(false);
        }

        private void OnShoot(InputAction.CallbackContext context)
        {
            bool isShooting = context.ReadValue<float>() > 0;
            OnShootChanged?.Invoke(isShooting);
        }

        private IEnumerator ActivateGunAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            _gun.SetActive(true);
        }
    }
}
