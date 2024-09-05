using System.Collections;
using UnityEngine;

namespace Player
{
    public class GunEquippedState : PlayerBaseState
    {
        public override void EnterState(PlayerStateManager player)
        {
            Debug.Log("GunState");
            player.Components.PlayerShootingScript.enabled = true;
            player.Components.Animator.SetTrigger(player.EquipObjectTrigger);
            player.Components.Animator.runtimeAnimatorController = player.Components.GunOverrideController;
        }

        public override void UpdateState(PlayerStateManager player)
        {
            
        }

        public override void ExitState(PlayerStateManager player)
        {
            player.Components.PlayerShootingScript.enabled = false;
        }

        
    }
}
