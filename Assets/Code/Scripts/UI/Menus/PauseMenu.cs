using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Player;
using General;
using System;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        #region VARIABLES
        private PlayerInputs _playerInputs;
        public static event Action<int> OnTimeChanged;
        [SerializeField] private GameObject _pauseMenuCanvas; 
        #endregion


        private void Awake()
        {
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
        }
        private void OpenMenu()
        {
            _playerInputs.InGame.Disable();
            _playerInputs.UI.Enable();
            _pauseMenuCanvas.SetActive(true);
            OnTimeChanged?.Invoke(0);
        }
        public void CloseMenu()
        {
            _playerInputs.InGame.Enable();
            _playerInputs.UI.Disable();
            _pauseMenuCanvas.SetActive(false);
            OnTimeChanged?.Invoke(1);
        }

        private void OnEnable()
        {
            _playerInputs.InGame.PauseGame.performed += OnOpenPauseMenu;


            _playerInputs.UI.ClosePauseMenu.performed += OnClosePauseMenu;

        }

        private void OnDisable()
        {
            _playerInputs.InGame.PauseGame.performed -= OnOpenPauseMenu;
            _playerInputs.UI.ClosePauseMenu.performed -= OnClosePauseMenu;

        }

        private void OnOpenPauseMenu(InputAction.CallbackContext context)
        {

            OpenMenu();
        }

        private void OnClosePauseMenu(InputAction.CallbackContext context)
        {
            CloseMenu();


        }


    }
}
