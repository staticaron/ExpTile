using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;

public class InputManager : MonoBehaviour
{
    private GridControlInputAction gridControlInputAction;
    private Camera mainCam;

    //Placable GameObjects
    [SerializeField] List<GameObject> placableObjects;

    //SOs
    [SerializeField] ObjectPlacementChannelSO objectPlacementChannelSO;

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
        gridControlInputAction.Grid.MouseRightClick.performed += ctx => MouseRightClick(ctx);
    }

    private void MouseClick(InputAction.CallbackContext ctx)
    {
        Vector2 clickPosInPixels = gridControlInputAction.Grid.MousePos.ReadValue<Vector2>();
        Vector2 clickPosWorld = GetWorldPosition(clickPosInPixels);

        objectPlacementChannelSO.RaisePlaceObject(clickPosWorld, placableObjects[0]);
    }

    private void MouseRightClick(InputAction.CallbackContext ctx)
    {
        Vector2 clickPosInPixels = gridControlInputAction.Grid.MousePos.ReadValue<Vector2>();
        Vector2 clickPosWorld = GetWorldPosition(clickPosInPixels);

        objectPlacementChannelSO.RaiseRemoveObject(clickPosWorld);
    }

    private Vector2 GetWorldPosition(Vector2 pixelPos)
    {
        return mainCam.ScreenToWorldPoint(pixelPos);
    }
}
