using UnityEngine;
using General;

namespace Player
{
    public class PlayerComponents : MonoBehaviour
    {
        //this script's execution time has been changed in project settings
        public static PlayerComponents Instance { get; private set; }

        #region VARIABLES
        [Header("General Components")]
        [SerializeField] private CharacterController _characterController;
        private PlayerInputs _playerInputs;

        [Header("Animations Realated")]
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatorOverrideController _gunOverrideController;
        [SerializeField] private AnimatorOverrideController _punchOverrideController;
        [SerializeField] private AnimatorOverrideController _torchOverrideController;
        [SerializeField] private AnimatorOverrideController _cameraOverrideController;

        [Header("Objects Related")]

        [SerializeField] private PlayerMovement _playerMovementScript;
        [SerializeField] private PlayerShooting _playerShootingScript;
        [SerializeField] private PlayerPunch _playerPunchScript;
        [SerializeField] private PlayerTorch _playerTorchScript;
        #endregion

        #region PROPERTIES
        public PlayerInputs PlayerInputs => _playerInputs;
        public Animator Animator => _animator;
        public AnimatorOverrideController GunOverrideController => _gunOverrideController;
        public AnimatorOverrideController PunchOverrideController => _punchOverrideController;
        public AnimatorOverrideController TorchOverrideController => _torchOverrideController;
        public AnimatorOverrideController CameraOverrideController => _cameraOverrideController;
        public CharacterController CharacterController => _characterController;
        public PlayerMovement PlayerMovementScript => _playerMovementScript;
        public PlayerShooting PlayerShootingScript => _playerShootingScript;
        public PlayerPunch PlayerPunchScript => _playerPunchScript;
        public PlayerTorch PlayerTorchScript => _playerTorchScript; 
        #endregion

        private void Awake()
        {

            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            _playerInputs = new PlayerInputs();

        }

        private void OnEnable()
        {
            _playerInputs?.InGame.Enable();
        }

        private void OnDisable()
        {
            _playerInputs?.InGame.Disable();
        }
       
    }
}
