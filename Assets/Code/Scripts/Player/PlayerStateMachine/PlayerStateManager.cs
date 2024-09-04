using General;
using UnityEngine;
using UnityEngine.InputSystem; 

namespace Player
{
    public class PlayerStateManager : MonoBehaviour
    {
        private Animator _animator;
        private AnimatorOverrideController _gunAnimatorOverride;
        private AnimatorOverrideController _punchAnimatorOverride;

        private PlayerBaseState _currentState;
        private PlayerBaseState _neutralState = new NeutralState();
        private PlayerBaseState _bareHandsState = new BareHandsState();
        private PlayerBaseState _gunEquippedState = new GunEquippedState();

        private PlayerInputs _inputs;

        [SerializeField] private string _equipGunParameter = "EquipGun";

        public PlayerBaseState BareHandsState => _bareHandsState;
        public PlayerBaseState NeutralState => _neutralState;
        public PlayerBaseState GunEquippedState => _gunEquippedState;
        public Animator Animator => _animator;
        public AnimatorOverrideController GunAnimatorOverride => _gunAnimatorOverride;
        public AnimatorOverrideController PunchAnimatorOverride => _punchAnimatorOverride;
        public PlayerInputs Inputs => _inputs;
        public string EquipGunParameter => _equipGunParameter;

        private void Start()
        {
            _inputs = PlayerComponents.Instance.PlayerInputs;
            _animator = PlayerComponents.Instance.Animator;
            _gunAnimatorOverride = PlayerComponents.Instance.GunOverrideController;
            _punchAnimatorOverride = PlayerComponents.Instance.PunchOverrideController;
            SwitchState(NeutralState);
        }

        

        private void Update()
        {
            _currentState.UpdateState(this);
        }

        public void SwitchState(PlayerBaseState newState)
        {
            _currentState?.ExitState(this);
            _currentState = newState;
            _currentState.EnterState(this);
        }
    }
}
