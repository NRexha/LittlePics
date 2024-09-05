using General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerTorch : MonoBehaviour
    {
        [SerializeField] private GameObject _torch;
        [SerializeField] private GameObject _light;
        [SerializeField] private float _activationDelay = 0.5f;
        private PlayerInputs _inputs;
        private bool _isTorchOn = false;
        

        private void Awake()
        {
            _inputs = PlayerComponents.Instance.PlayerInputs;
        }
        private void OnEnable()
        {
            StartCoroutine(SwitchTorchAfterDelay(true, _activationDelay));
            _inputs.InGame.TriggerActiveObject.performed += OnTriggerTorch;
        }
        private void OnDisable()
        {
            StartCoroutine(SwitchTorchAfterDelay(false, _activationDelay));
            _inputs.InGame.TriggerActiveObject.performed -= OnTriggerTorch;
        }

        private IEnumerator SwitchTorchAfterDelay(bool trigger, float delay)
        {
            yield return new WaitForSeconds(delay);
            _torch.SetActive(trigger);
            _light.SetActive(trigger);
            _isTorchOn = trigger;
        }

        private void OnTriggerTorch(InputAction.CallbackContext context)
        {
            _isTorchOn = !_isTorchOn;
            _light.SetActive(_isTorchOn);
        }
    }
}
