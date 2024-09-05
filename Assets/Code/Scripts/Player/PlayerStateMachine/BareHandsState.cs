using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class BareHandsState : PlayerBaseState
    {
        

        public override void EnterState(PlayerStateManager player)
        {
            Debug.Log("HandsState");
            player.Components.Animator.SetTrigger(player.EquipObjectTrigger);
            player.Components.Animator.runtimeAnimatorController = player.Components.PunchOverrideController;
            player.Components.PlayerPunchScript.enabled = true;
        }

        public override void UpdateState(PlayerStateManager player)
        {

        }

        public override void ExitState(PlayerStateManager player)
        {
            player.Components.PlayerPunchScript.enabled = false;
        }

        
    }
}
