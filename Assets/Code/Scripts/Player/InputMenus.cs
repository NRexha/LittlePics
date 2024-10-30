using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace General
{
    public class InputMenus : MonoBehaviour
    {
        private PlayerInputs _playerInputs;
        public static event Action<int> OnTimeChanged;


        private void Awake()
        {
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
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

            _playerInputs.InGame.Disable();
            _playerInputs.UI.Enable();
            Debug.Log("InGame is now disabled");
            OnTimeChanged?.Invoke(0);
        }

        private void OnClosePauseMenu(InputAction.CallbackContext context)
        {

            _playerInputs.InGame.Enable();
            _playerInputs.UI.Disable();
            Debug.Log("InGame is now enabled");
            OnTimeChanged?.Invoke(1);
        }
    }


}
