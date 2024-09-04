using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class BareHandsState : PlayerBaseState
    {
        

        public override void EnterState(PlayerStateManager player)
        {
            player.Animator.runtimeAnimatorController = player.PunchAnimatorOverride;
        }

        public override void UpdateState(PlayerStateManager player)
        {

        }

        public override void ExitState(PlayerStateManager player)
        {
            
        }

        
    }
}
