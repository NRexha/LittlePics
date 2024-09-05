using General;
using UnityEngine;
using UnityEngine.InputSystem; 

namespace Player
{
    public class PlayerStateManager : MonoBehaviour
    {

        [Header("States")]

        private PlayerBaseState _currentState;
        private PlayerBaseState _cameraEquippedState = new CameraEquippedState();
        private PlayerBaseState _torchEquippedState = new TorchEquippedState();
        private PlayerBaseState _bareHandsState = new BareHandsState();
        private PlayerBaseState _gunEquippedState = new GunEquippedState();


        [Header("References")]
        [SerializeField] private string _equipObjectTrigger = "EquipObject";
        private PlayerComponents _components;

        public PlayerBaseState BareHandsState => _bareHandsState;
       
        public PlayerBaseState GunEquippedState => _gunEquippedState;
        public PlayerBaseState CameraEquippedState => _cameraEquippedState;
        public PlayerBaseState TorchEquippedState => _torchEquippedState;
        
        public string EquipObjectTrigger => _equipObjectTrigger;
        public PlayerComponents Components => _components;

        private void OnEnable()
        {
            Equipment.OnGunEquip += EquipGun;
            Equipment.OnTorchEquip += EquipTorch;
            Equipment.OnCameraEquip += EquipCamera;
            Equipment.OnPunchEquip += EquipPunch;
        }

        private void OnDisable()
        {
            Equipment.OnGunEquip -= EquipGun;
            Equipment.OnTorchEquip -= EquipTorch;
            Equipment.OnCameraEquip -= EquipCamera;
            Equipment.OnPunchEquip -= EquipPunch;
        }
        private void Awake()
        {
            _components = PlayerComponents.Instance;
        }
        private void Start()
        {
            SwitchState(_bareHandsState);
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

        private void EquipGun()
        {
            SwitchState(_gunEquippedState);
            
        }

        private void EquipTorch()
        {
            SwitchState(_torchEquippedState);
            
        }

        private void EquipCamera()
        {
            SwitchState(_cameraEquippedState);
            
        }

        private void EquipPunch()
        {
            SwitchState(_bareHandsState);
            
        }
    }
}
