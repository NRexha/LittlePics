//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Code/Inputs/PlayerInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace General
{
    public partial class @PlayerInputs: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""68f62954-59a1-4d23-a7ad-f42245f2d4df"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6ebe1907-7e6d-4e6c-8051-a989b08776ef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d5a81231-8f93-446c-b5f7-28421bd32ab8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Climb"",
                    ""type"": ""Value"",
                    ""id"": ""c0693005-2aa9-493d-9f1f-c53244b9d3f6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Equipment"",
                    ""type"": ""Value"",
                    ""id"": ""2f76e81b-5fb9-43ca-b360-e67de1729a07"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TriggerActiveObject"",
                    ""type"": ""Button"",
                    ""id"": ""a993b15e-25bb-44f1-83ab-9e3fc589eed7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cc33d32b-4768-4947-96ea-d1ca28cb9cdb"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.1,max=1)"",
                    ""groups"": ""GamepadControl"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ffc28d2-bbbb-46f1-93e4-a974decf3b79"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControl"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6289beb-4ff2-4efb-9a73-c33e999a7d68"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControl"",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c2bfb821-06a3-49ea-b1c0-338790c6833a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equipment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3d30b73a-83f4-4ed5-ae46-6654bf7fd3a1"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControl"",
                    ""action"": ""Equipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cfe8e567-7d27-4890-867e-18bb0c351d46"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControl"",
                    ""action"": ""Equipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""146b2df5-d29d-4b4a-825e-c764892e3fe3"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControl"",
                    ""action"": ""Equipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4069f1d8-e042-42bb-b68b-21dada52f9db"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControl"",
                    ""action"": ""Equipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""88c2ce5e-e38f-40b1-aa78-5bb331a8770d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControl"",
                    ""action"": ""TriggerActiveObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57030bb1-3b84-4542-9fc7-7d5425782be4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamepadControl"",
                    ""action"": ""TriggerActiveObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GamepadControl"",
            ""bindingGroup"": ""GamepadControl"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // InGame
            m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
            m_InGame_Move = m_InGame.FindAction("Move", throwIfNotFound: true);
            m_InGame_Sprint = m_InGame.FindAction("Sprint", throwIfNotFound: true);
            m_InGame_Climb = m_InGame.FindAction("Climb", throwIfNotFound: true);
            m_InGame_Equipment = m_InGame.FindAction("Equipment", throwIfNotFound: true);
            m_InGame_TriggerActiveObject = m_InGame.FindAction("TriggerActiveObject", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // InGame
        private readonly InputActionMap m_InGame;
        private List<IInGameActions> m_InGameActionsCallbackInterfaces = new List<IInGameActions>();
        private readonly InputAction m_InGame_Move;
        private readonly InputAction m_InGame_Sprint;
        private readonly InputAction m_InGame_Climb;
        private readonly InputAction m_InGame_Equipment;
        private readonly InputAction m_InGame_TriggerActiveObject;
        public struct InGameActions
        {
            private @PlayerInputs m_Wrapper;
            public InGameActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_InGame_Move;
            public InputAction @Sprint => m_Wrapper.m_InGame_Sprint;
            public InputAction @Climb => m_Wrapper.m_InGame_Climb;
            public InputAction @Equipment => m_Wrapper.m_InGame_Equipment;
            public InputAction @TriggerActiveObject => m_Wrapper.m_InGame_TriggerActiveObject;
            public InputActionMap Get() { return m_Wrapper.m_InGame; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
            public void AddCallbacks(IInGameActions instance)
            {
                if (instance == null || m_Wrapper.m_InGameActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_InGameActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Climb.started += instance.OnClimb;
                @Climb.performed += instance.OnClimb;
                @Climb.canceled += instance.OnClimb;
                @Equipment.started += instance.OnEquipment;
                @Equipment.performed += instance.OnEquipment;
                @Equipment.canceled += instance.OnEquipment;
                @TriggerActiveObject.started += instance.OnTriggerActiveObject;
                @TriggerActiveObject.performed += instance.OnTriggerActiveObject;
                @TriggerActiveObject.canceled += instance.OnTriggerActiveObject;
            }

            private void UnregisterCallbacks(IInGameActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Sprint.started -= instance.OnSprint;
                @Sprint.performed -= instance.OnSprint;
                @Sprint.canceled -= instance.OnSprint;
                @Climb.started -= instance.OnClimb;
                @Climb.performed -= instance.OnClimb;
                @Climb.canceled -= instance.OnClimb;
                @Equipment.started -= instance.OnEquipment;
                @Equipment.performed -= instance.OnEquipment;
                @Equipment.canceled -= instance.OnEquipment;
                @TriggerActiveObject.started -= instance.OnTriggerActiveObject;
                @TriggerActiveObject.performed -= instance.OnTriggerActiveObject;
                @TriggerActiveObject.canceled -= instance.OnTriggerActiveObject;
            }

            public void RemoveCallbacks(IInGameActions instance)
            {
                if (m_Wrapper.m_InGameActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IInGameActions instance)
            {
                foreach (var item in m_Wrapper.m_InGameActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_InGameActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public InGameActions @InGame => new InGameActions(this);
        private int m_GamepadControlSchemeIndex = -1;
        public InputControlScheme GamepadControlScheme
        {
            get
            {
                if (m_GamepadControlSchemeIndex == -1) m_GamepadControlSchemeIndex = asset.FindControlSchemeIndex("GamepadControl");
                return asset.controlSchemes[m_GamepadControlSchemeIndex];
            }
        }
        public interface IInGameActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnClimb(InputAction.CallbackContext context);
            void OnEquipment(InputAction.CallbackContext context);
            void OnTriggerActiveObject(InputAction.CallbackContext context);
        }
    }
}
