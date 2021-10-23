using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private GridControlInputAction gridControlInputAction;
    private Camera mainCam;

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
        mainCam = Camera.main;

        //Link Controls
        gridControlInputAction.Grid.MouseClick.performed += ctx => MouseClick(ctx);
    }

    private void MouseClick(InputAction.CallbackContext ctx)
    {
        Vector2 clickPosInPixels = gridControlInputAction.Grid.MousePos.ReadValue<Vector2>();
        Vector2 clickPosWorld = GetWorldPosition(clickPosInPixels);
        //Call Place Object
        gridChannelSO.RaisePlaceObject(clickPosWorld, 0);
    }

    private Vector2 GetWorldPosition(Vector2 pixelPos)
    {
        return mainCam.ScreenToWorldPoint(pixelPos);
    }
}
