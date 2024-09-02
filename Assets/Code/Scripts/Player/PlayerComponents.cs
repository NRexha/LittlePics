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
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerShooting _playerShootingScript;
        public PlayerInputs PlayerInputs => _playerInputs;
        public Animator Animator => _animator;
        public AnimatorOverrideController GunOverrideController => _gunOverrideController;
        public CharacterController CharacterController => _characterController;
        public PlayerShooting PlayerShootingScript => _playerShootingScript;

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
