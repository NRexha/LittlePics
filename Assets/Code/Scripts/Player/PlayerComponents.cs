using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using General;

namespace Player
{
    public class PlayerComponents : MonoBehaviour
    {
        #region VARIABLES
        [Header("Components")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Camera _camera;
        [SerializeField] private Animator _animator;
        private PlayerInputs _playerInputs; 
        #endregion

        #region PROPERTIES
        public Camera Camera => _camera;
        public PlayerInputs PlayerInputs => _playerInputs;

        public CharacterController CharacterController => _characterController; 
        public Animator Animator => _animator;
        #endregion

        #region SINGLETON
        public static PlayerComponents Instance { get; private set; }


        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }

            InitializeComponenets();
        }
        #endregion

        #region INITIALIZE
        private void InitializeComponenets()
        {
            _playerInputs = new PlayerInputs();
        } 
        #endregion
    }
}
