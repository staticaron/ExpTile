// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/GridControlInputAction.inputactions'

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
                },
                {
                    ""name"": ""MouseRightClick"",
                    ""type"": ""Button"",
                    ""id"": ""fc6ed51f-ee5d-4836-a84f-aa9f4bb0309c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMouseClickDown"",
                    ""type"": ""Button"",
                    ""id"": ""d6c49b77-cf11-4f35-9d2a-fedaf8013477"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMouseClickUp"",
                    ""type"": ""Button"",
                    ""id"": ""585e4ef5-94cc-4d9d-8ee9-db049e896439"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMouseClickDown"",
                    ""type"": ""Button"",
                    ""id"": ""013a11d4-7f64-430d-af69-bd5dca59ce7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMouseClickUp"",
                    ""type"": ""Button"",
                    ""id"": ""1a7ecb2e-5262-4242-b0e4-d326f8c37b48"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""06d1a299-7add-47f1-ba28-1d622418ddce"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseRightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7a8f21a-2a83-4943-a70b-009edf7c5acd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMouseClickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""755c4e91-77e0-4eee-b4e8-f17c153a9791"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMouseClickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""370f2224-f0e2-416e-b067-82647f4447b9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMouseClickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a393ffa2-2f23-4767-a79e-623f03ed8a57"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMouseClickUp"",
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
        m_Grid_MouseRightClick = m_Grid.FindAction("MouseRightClick", throwIfNotFound: true);
        m_Grid_LeftMouseClickDown = m_Grid.FindAction("LeftMouseClickDown", throwIfNotFound: true);
        m_Grid_LeftMouseClickUp = m_Grid.FindAction("LeftMouseClickUp", throwIfNotFound: true);
        m_Grid_RightMouseClickDown = m_Grid.FindAction("RightMouseClickDown", throwIfNotFound: true);
        m_Grid_RightMouseClickUp = m_Grid.FindAction("RightMouseClickUp", throwIfNotFound: true);
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
    private readonly InputAction m_Grid_MouseRightClick;
    private readonly InputAction m_Grid_LeftMouseClickDown;
    private readonly InputAction m_Grid_LeftMouseClickUp;
    private readonly InputAction m_Grid_RightMouseClickDown;
    private readonly InputAction m_Grid_RightMouseClickUp;
    public struct GridActions
    {
        private @GridControlInputAction m_Wrapper;
        public GridActions(@GridControlInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePos => m_Wrapper.m_Grid_MousePos;
        public InputAction @MouseClick => m_Wrapper.m_Grid_MouseClick;
        public InputAction @MouseRightClick => m_Wrapper.m_Grid_MouseRightClick;
        public InputAction @LeftMouseClickDown => m_Wrapper.m_Grid_LeftMouseClickDown;
        public InputAction @LeftMouseClickUp => m_Wrapper.m_Grid_LeftMouseClickUp;
        public InputAction @RightMouseClickDown => m_Wrapper.m_Grid_RightMouseClickDown;
        public InputAction @RightMouseClickUp => m_Wrapper.m_Grid_RightMouseClickUp;
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
                @MouseRightClick.started -= m_Wrapper.m_GridActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnMouseRightClick;
                @MouseRightClick.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnMouseRightClick;
                @LeftMouseClickDown.started -= m_Wrapper.m_GridActionsCallbackInterface.OnLeftMouseClickDown;
                @LeftMouseClickDown.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnLeftMouseClickDown;
                @LeftMouseClickDown.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnLeftMouseClickDown;
                @LeftMouseClickUp.started -= m_Wrapper.m_GridActionsCallbackInterface.OnLeftMouseClickUp;
                @LeftMouseClickUp.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnLeftMouseClickUp;
                @LeftMouseClickUp.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnLeftMouseClickUp;
                @RightMouseClickDown.started -= m_Wrapper.m_GridActionsCallbackInterface.OnRightMouseClickDown;
                @RightMouseClickDown.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnRightMouseClickDown;
                @RightMouseClickDown.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnRightMouseClickDown;
                @RightMouseClickUp.started -= m_Wrapper.m_GridActionsCallbackInterface.OnRightMouseClickUp;
                @RightMouseClickUp.performed -= m_Wrapper.m_GridActionsCallbackInterface.OnRightMouseClickUp;
                @RightMouseClickUp.canceled -= m_Wrapper.m_GridActionsCallbackInterface.OnRightMouseClickUp;
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
                @MouseRightClick.started += instance.OnMouseRightClick;
                @MouseRightClick.performed += instance.OnMouseRightClick;
                @MouseRightClick.canceled += instance.OnMouseRightClick;
                @LeftMouseClickDown.started += instance.OnLeftMouseClickDown;
                @LeftMouseClickDown.performed += instance.OnLeftMouseClickDown;
                @LeftMouseClickDown.canceled += instance.OnLeftMouseClickDown;
                @LeftMouseClickUp.started += instance.OnLeftMouseClickUp;
                @LeftMouseClickUp.performed += instance.OnLeftMouseClickUp;
                @LeftMouseClickUp.canceled += instance.OnLeftMouseClickUp;
                @RightMouseClickDown.started += instance.OnRightMouseClickDown;
                @RightMouseClickDown.performed += instance.OnRightMouseClickDown;
                @RightMouseClickDown.canceled += instance.OnRightMouseClickDown;
                @RightMouseClickUp.started += instance.OnRightMouseClickUp;
                @RightMouseClickUp.performed += instance.OnRightMouseClickUp;
                @RightMouseClickUp.canceled += instance.OnRightMouseClickUp;
            }
        }
    }
    public GridActions @Grid => new GridActions(this);
    public interface IGridActions
    {
        void OnMousePos(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
        void OnMouseRightClick(InputAction.CallbackContext context);
        void OnLeftMouseClickDown(InputAction.CallbackContext context);
        void OnLeftMouseClickUp(InputAction.CallbackContext context);
        void OnRightMouseClickDown(InputAction.CallbackContext context);
        void OnRightMouseClickUp(InputAction.CallbackContext context);
    }
}
