using UnityEngine;
using General;

namespace Player
{
    public class PlayerComponents : MonoBehaviour
    {
        public static PlayerComponents Instance { get; private set; }

        private PlayerInputs _playerInputs;
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatorOverrideController _gunOverrideController;
        [SerializeField] private AnimatorOverrideController _punchOverrideController;
        [SerializeField] private AnimatorOverrideController _torchOverrideController;
        [SerializeField] private AnimatorOverrideController _cameraOverrideController;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerMovement _playerMovementScript;
        [SerializeField] private PlayerShooting _playerShootingScript;
        [SerializeField] private PlayerPunch _playerPunchScript;
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
