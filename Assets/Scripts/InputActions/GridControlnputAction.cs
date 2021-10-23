// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputActions/GridControlnputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GridControlnputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GridControlnputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GridControlnputAction"",
    ""maps"": [
        {
            ""name"": ""Grid"",
            ""id"": ""94b2c7df-02ee-4b7a-9681-ef6a93f7efe7"",
            ""actions"": [
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""a17416fc-7811-455d-9838-53714e1b2996"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c2e7f0db-c74b-4f47-b6ff-2126ff4653e4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Grid
        m_Grid = asset.FindActionMap("Grid", throwIfNotFound: true);
        m_Grid_Mouse = m_Grid.FindAction("Mouse", throwIfNotFound: true);
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

    // Grid
    private readonly InputActionMap m_Grid;
    private IGridActions m_GridActionsCallbackInterface;
    private readonly InputAction m_Grid_Mouse;
    public struct GridActions
    {
        private @GridControlnputAction m_Wrapper;
        public GridActions(@GridControlnputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouse => m_Wrapper.m_Grid_Mouse;
        public InputActionMap Get() { return m_Wrapper.m_Grid; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GridActions set) { return set.Get(); }
        public void SetCallbacks(IGridActions instance)
        {
            if (m_Wrapper.m_GridActionsCallbackInterface != null)
            {
                @Mouse.started -= m_Wrapper.m_GridActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnMouse;
            }
            m_Wrapper.m_GridActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
            }
        }
    }
    public GridActions @Grid => new GridActions(this);
    public interface IGridActions
    {
        void OnMouse(InputAction.CallbackContext context);
    }
}
