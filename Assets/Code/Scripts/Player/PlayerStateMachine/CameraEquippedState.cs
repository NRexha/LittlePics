using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class CameraEquippedState : PlayerBaseState
    {
        public override void EnterState(PlayerStateManager player)
        {
            Debug.Log("CameraState");
            player.Components.Animator.SetTrigger(player.EquipObjectTrigger);
            player.Components.Animator.runtimeAnimatorController = player.Components.CameraOverrideController;
        }

        public override void ExitState(PlayerStateManager player)
        {
            
        }

        public override void UpdateState(PlayerStateManager player)
        {
           
        }

        
        
    }
}
