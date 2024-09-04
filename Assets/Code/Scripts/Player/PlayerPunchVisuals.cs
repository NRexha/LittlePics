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
            

            switch (comboStep)
            {
                case 1:
                    _animator.SetTrigger($"{_trigger}{comboStep}");
                    break;
                case 2:
                    _animator.SetTrigger($"{_trigger}{comboStep}");
                    break;
                case 3:
                    _animator.SetTrigger($"{_trigger}{comboStep}");
                    break;
                default:
                    break;
            }
        }
    }
}