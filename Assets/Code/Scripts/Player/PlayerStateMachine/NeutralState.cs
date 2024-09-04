using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class NeutralState : PlayerBaseState
    {
        private bool _isSubscribed = false;
        private PlayerStateManager _player;
        public override void EnterState(PlayerStateManager player)
        {
            _player = player;

            if (!_isSubscribed)
            {
                player.Inputs.InGame.EquipGun.performed += OnEquipGun;
                _isSubscribed = true;

            }
            Debug.Log("In neutral state");
        }

        public override void ExitState(PlayerStateManager player)
        {
            if (_isSubscribed)
            {
                player.Inputs.InGame.EquipGun.performed -= OnEquipGun;
                _isSubscribed = false;
            }
        }

        public override void UpdateState(PlayerStateManager player)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                player.SwitchState(player.BareHandsState);
            }
        }

        private void OnEquipGun(InputAction.CallbackContext context)
        {
            _player.SwitchState(_player.GunEquippedState);
        }


    }
}
