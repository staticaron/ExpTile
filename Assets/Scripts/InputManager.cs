using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private GridControlInputAction gridControlInputAction;


    //SOs
    [SerializeField] GridChannelSO gridChannelSO;

    private void OnEnable()
    {
        gridControlInputAction.Enable();
    }

    private void OnDisable()
    {
        gridControlInputAction.Disable();
    }

    private void Awake()
    {
        gridControlInputAction = new GridControlInputAction();

        //Link Controls
        gridControlInputAction.Grid.MouseClick.performed += ctx => MouseClick(ctx);
    }

    private void MouseClick(InputAction.CallbackContext ctx)
    {
        Vector2 clickPos = gridControlInputAction.Grid.MousePos.ReadValue<Vector2>();
        //Call Place Object
        gridChannelSO.RaisePlaceObject(clickPos, 13);
    }
}
