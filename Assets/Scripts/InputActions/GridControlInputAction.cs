// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputActions/GridControlInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GridControlInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GridControlInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GridControlInputAction"",
    ""maps"": [
        {
            ""name"": ""Grid"",
            ""id"": ""c696f8c8-97aa-4046-b86c-d63097b17972"",
            ""actions"": [
                {
                    ""name"": ""MousePos"",
                    ""type"": ""Value"",
                    ""id"": ""242196db-bb3a-460a-ba6d-cad95f9ddd38"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""ac367d1e-eca0-4be1-b0f0-507a2e872d31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7cf2eb9f-e625-4af0-bd45-ff23e9892c85"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""701c496d-5ab4-4338-bbd9-3ed28a6f9ceb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
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
        m_Grid_MousePos = m_Grid.FindAction("MousePos", throwIfNotFound: true);
        m_Grid_MouseClick = m_Grid.FindAction("MouseClick", throwIfNotFound: true);
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
    private readonly InputAction m_Grid_MousePos;
    private readonly InputAction m_Grid_MouseClick;
    public struct GridActions
    {
        private @GridControlInputAction m_Wrapper;
        public GridActions(@GridControlInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePos => m_Wrapper.m_Grid_MousePos;
        public InputAction @MouseClick => m_Wrapper.m_Grid_MouseClick;
        public InputActionMap Get() { return m_Wrapper.m_Grid; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GridActions set) { return set.Get(); }
        public void SetCallbacks(IGridActions instance)
        {
            if (m_Wrapper.m_GridActionsCallbackInterface != null)
            {
                @MousePos.started -= m_Wrapper.m_GridActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnMousePos;
                @MouseClick.started -= m_Wrapper.m_GridActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnMouseClick;
            }
            m_Wrapper.m_GridActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
            }
        }
    }
    public GridActions @Grid => new GridActions(this);
    public interface IGridActions
    {
        void OnMousePos(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
    }
}
