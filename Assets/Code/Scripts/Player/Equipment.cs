using General;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Equipment : MonoBehaviour
    {
        public static event Action OnGunEquip;
        public static event Action OnTorchEquip;
        public static event Action OnCameraEquip;
        public static event Action OnPunchEquip;

        private enum EEquipmentType { Gun, Torch, Camera, Punch }
        private EEquipmentType _currentEquipment = EEquipmentType.Punch;

        private PlayerInputs _playerInputs;

        private void Awake()
        {
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
        }

        private void OnEnable()
        {
            _playerInputs.InGame.Equipment.performed += OnEquip;
        }

        private void OnDisable()
        {
            _playerInputs.InGame.Equipment.performed -= OnEquip;
        }

        private void OnEquip(InputAction.CallbackContext context)
        {
            Vector2 equipInput = context.ReadValue<Vector2>();

            if (equipInput == Vector2.up)
            {
                EquipItem(EEquipmentType.Gun, OnGunEquip);
            }
            else if (equipInput == Vector2.right)
            {
                EquipItem(EEquipmentType.Camera, OnCameraEquip);
            }
            else if (equipInput == Vector2.down)
            {
                EquipItem(EEquipmentType.Torch, OnTorchEquip);
            }
            else if (equipInput == Vector2.left)
            {
                EquipItem(EEquipmentType.Punch, OnPunchEquip);
            }
        }

        private void EquipItem(EEquipmentType equipmentType, Action equipEvent)
        {
            if (_currentEquipment != equipmentType)
            {
                _currentEquipment = equipmentType;
                equipEvent?.Invoke();
            }
        }

        
    }
}
