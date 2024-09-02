using System.Collections;
using UnityEngine;

namespace Player
{
    public class GunEquippedState : PlayerBaseState
    {
        public override void EnterState(PlayerStateManager player)
        {
            player.StartCoroutine(EquipGun(player));
            PlayerComponents.Instance.PlayerShootingScript.enabled = true;
        }

        public override void UpdateState(PlayerStateManager player)
        {
            
        }

        public override void ExitState(PlayerStateManager player)
        {
            PlayerComponents.Instance.PlayerShootingScript.enabled = false;
        }

        private IEnumerator EquipGun(PlayerStateManager player)
        {
            player.Animator.SetTrigger(player.EquipGunParameter);
            yield return new WaitForEndOfFrame();
            player.Animator.runtimeAnimatorController = player.GunAnimatorOverride;
        }
    }
}
