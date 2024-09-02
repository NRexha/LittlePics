using Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DiegeticHUD : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private Slider _staminaSlider;


        private void OnEnable()
        {
            PlayerStamina.OnStaminaChanged += HandleStaminaChange;
        }

        private void OnDisable()
        {
            PlayerStamina.OnStaminaChanged -= HandleStaminaChange;
        }



        private void HandleStaminaChange(float staminaNormalized)
        {
            if (_staminaSlider != null)
            {
                _staminaSlider.value = staminaNormalized;
            }

        }

    }
}
