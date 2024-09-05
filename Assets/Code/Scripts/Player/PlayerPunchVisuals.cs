using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerPunchVisuals : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _trigger = "Melee";

        private void OnEnable()
        {
            PlayerPunch.OnComboStepChanged += HandleComboStep;
        }

        private void OnDisable()
        {
            PlayerPunch.OnComboStepChanged -= HandleComboStep;
        }

        private void HandleComboStep(int comboStep)
        {
            if (comboStep >= 1 && comboStep <= 3)
            {
                _animator.SetTrigger($"{_trigger}{comboStep}");
            }
        }
    }
}
