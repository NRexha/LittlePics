using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class TorchEquippedState : PlayerBaseState
    {
        public override void EnterState(PlayerStateManager player)
        {
            Debug.Log("TorchState");
            player.Components.Animator.SetTrigger(player.EquipObjectTrigger);
            player.Components.Animator.runtimeAnimatorController = player.Components.TorchOverrideController;
        }

        public override void ExitState(PlayerStateManager player)
        {
           
        }

        public override void UpdateState(PlayerStateManager player)
        {
            
        }

       
    }
}
