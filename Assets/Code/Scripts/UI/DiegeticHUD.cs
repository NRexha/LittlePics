using Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

namespace UI
{
    public class DiegeticHUD : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private Slider _staminaSlider;
        [SerializeField] private Material _sliderStaminaMaterial;
        [SerializeField] private string _staminaAlphaParameter = "_Alpha";
        [SerializeField] private float _standByDuration = 3f;
        [SerializeField] private float _fadeSpeed = 0.5f;

        private float _timer = 0f;
        private bool _isFading = false;
        private bool _isStaminaFull = false;

        private void OnEnable()
        {
            PlayerStamina.OnStaminaChanged += HandleStaminaChange;
            _sliderStaminaMaterial.SetFloat(_staminaAlphaParameter, 0f);
        }

        private void OnDisable()
        {
            PlayerStamina.OnStaminaChanged -= HandleStaminaChange;
            _sliderStaminaMaterial.SetFloat(_staminaAlphaParameter, 1f);
        }

        private void Update()
        {
            if (_isStaminaFull && !_isFading)
            {
                _timer += Time.deltaTime;

                if (_timer >= _standByDuration)
                {
                    StartCoroutine(FadeAlphaToZero());
                }
            }
        }

        private void HandleStaminaChange(float staminaNormalized)
        {
            if (_staminaSlider != null)
            {
                _staminaSlider.value = staminaNormalized;
            }

            if (staminaNormalized < 1f)
            {
                StopAllCoroutines();
                SetAlpha(1f);
                _timer = 0f;
                _isStaminaFull = false;
            }
            else if (staminaNormalized == 1f && !_isFading)
            {
                _isStaminaFull = true;
            }
        }

        private IEnumerator FadeAlphaToZero()
        {
            _isFading = true;
            float currentAlpha = _sliderStaminaMaterial.GetFloat(_staminaAlphaParameter);

            while (currentAlpha > 0f)
            {
                currentAlpha -= Time.deltaTime * _fadeSpeed;
                SetAlpha(Mathf.Max(currentAlpha, 0f));
                yield return null;
            }

            _isFading = false;
        }

        private void SetAlpha(float value)
        {
            _sliderStaminaMaterial.SetFloat(_staminaAlphaParameter, value);
        }
    }
}
