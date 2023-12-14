//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Custom Inputs/RatTrapInputAsset.inputactions
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

public partial class @RatTrapInputAsset: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @RatTrapInputAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RatTrapInputAsset"",
    ""maps"": [
        {
            ""name"": ""RatTrapActions"",
            ""id"": ""093d9961-d212-41a4-9678-b2ba3e798af2"",
            ""actions"": [
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""51ad8906-6ebe-488b-9e76-3536683fb042"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""24210c6b-9e5d-4a65-87c7-fca164b19814"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6ef5c506-04be-4a64-984d-719a04b2342d"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcfbadf3-f006-4ce1-844b-98ffd38bcff9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d30350f1-128b-4314-b95e-93eb92695c2f"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d038dc4-5125-4f96-8a1a-735eaac8280c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // RatTrapActions
        m_RatTrapActions = asset.FindActionMap("RatTrapActions", throwIfNotFound: true);
        m_RatTrapActions_MoveUp = m_RatTrapActions.FindAction("MoveUp", throwIfNotFound: true);
        m_RatTrapActions_MoveDown = m_RatTrapActions.FindAction("MoveDown", throwIfNotFound: true);
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

    // RatTrapActions
    private readonly InputActionMap m_RatTrapActions;
    private List<IRatTrapActionsActions> m_RatTrapActionsActionsCallbackInterfaces = new List<IRatTrapActionsActions>();
    private readonly InputAction m_RatTrapActions_MoveUp;
    private readonly InputAction m_RatTrapActions_MoveDown;
    public struct RatTrapActionsActions
    {
        private @RatTrapInputAsset m_Wrapper;
        public RatTrapActionsActions(@RatTrapInputAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveUp => m_Wrapper.m_RatTrapActions_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_RatTrapActions_MoveDown;
        public InputActionMap Get() { return m_Wrapper.m_RatTrapActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RatTrapActionsActions set) { return set.Get(); }
        public void AddCallbacks(IRatTrapActionsActions instance)
        {
            if (instance == null || m_Wrapper.m_RatTrapActionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_RatTrapActionsActionsCallbackInterfaces.Add(instance);
            @MoveUp.started += instance.OnMoveUp;
            @MoveUp.performed += instance.OnMoveUp;
            @MoveUp.canceled += instance.OnMoveUp;
            @MoveDown.started += instance.OnMoveDown;
            @MoveDown.performed += instance.OnMoveDown;
            @MoveDown.canceled += instance.OnMoveDown;
        }

        private void UnregisterCallbacks(IRatTrapActionsActions instance)
        {
            @MoveUp.started -= instance.OnMoveUp;
            @MoveUp.performed -= instance.OnMoveUp;
            @MoveUp.canceled -= instance.OnMoveUp;
            @MoveDown.started -= instance.OnMoveDown;
            @MoveDown.performed -= instance.OnMoveDown;
            @MoveDown.canceled -= instance.OnMoveDown;
        }

        public void RemoveCallbacks(IRatTrapActionsActions instance)
        {
            if (m_Wrapper.m_RatTrapActionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IRatTrapActionsActions instance)
        {
            foreach (var item in m_Wrapper.m_RatTrapActionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_RatTrapActionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public RatTrapActionsActions @RatTrapActions => new RatTrapActionsActions(this);
    public interface IRatTrapActionsActions
    {
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
    }
}