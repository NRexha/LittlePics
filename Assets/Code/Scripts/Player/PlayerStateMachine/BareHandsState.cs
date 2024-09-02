using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class BareHandsState : PlayerBaseState
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
        }

        public override void UpdateState(PlayerStateManager player)
        {

        }

        public override void ExitState(PlayerStateManager player)
        {
            if (_isSubscribed)
            {
                player.Inputs.InGame.EquipGun.performed -= OnEquipGun;
                _isSubscribed = false;
            }
        }

        private void OnEquipGun(InputAction.CallbackContext context)
        {
            _player.SwitchState(_player.GunEquippedState);
        }
    }
}
