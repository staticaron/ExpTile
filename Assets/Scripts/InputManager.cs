using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public enum DrawState
{
    Drawing,
    Erasing,
    Idle
}

public class InputManager : MonoBehaviour
{
    private GridControlInputAction gridControlInputAction;
    private Camera mainCam;

    [SerializeField] DrawState currentDrawState = DrawState.Idle;

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
        gridControlInputAction.Grid.MouseClick.performed += ctx => MouseClick();
        gridControlInputAction.Grid.MouseRightClick.performed += ctx => MouseRightClick();

        gridControlInputAction.Grid.LeftMouseClickDown.performed += ctx => StartDrawing();
        gridControlInputAction.Grid.LeftMouseClickUp.performed += ctx => EndDrawing();
    }

    private void Update()
    {
        if (currentDrawState == DrawState.Drawing)
        {
            MouseClick();
        }
    }

    private void StartDrawing()
    {
        currentDrawState = DrawState.Drawing;
    }

    private void EndDrawing()
    {
        currentDrawState = DrawState.Idle;
    }

    private void StartErasing()
    {
        currentDrawState = DrawState.Erasing;
    }

    private void EndErasing()
    {
        currentDrawState = DrawState.Idle;
    }

    private void MouseClick()
    {
        Vector2 clickPosInPixels = gridControlInputAction.Grid.MousePos.ReadValue<Vector2>();
        Vector2 clickPosWorld = GetWorldPosition(clickPosInPixels);

        objectPlacementChannelSO.RaisePlaceObject(clickPosWorld, placableObjects[0]);
    }

    private void MouseRightClick()
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
