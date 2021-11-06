using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public enum DrawState
{
    Draw,
    Erase,
    Idle
}

public class InputManager : MonoBehaviour
{
    private GridControlInputAction gridControlInputAction;
    private Camera mainCam;

    [SerializeField] DrawState currentDrawState = DrawState.Idle;

    GameObject selectedPlacableObject = default;

    //SOs
    [SerializeField] ObjectPlacementChannelSO objectPlacementChannelSO;
    [SerializeField] ObjectManagerChannelSO objectManagerChannelSO;

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

        gridControlInputAction.Grid.LeftMouseClickDown.performed += ctx => StartDrawing();
        gridControlInputAction.Grid.LeftMouseClickUp.performed += ctx => EndDrawing();

        gridControlInputAction.Grid.RightMouseClickDown.performed += ctx => StartErasing();
        gridControlInputAction.Grid.RightMouseClickUp.performed += ctx => EndErasing();
    }

    private void Update()
    {
        if (currentDrawState == DrawState.Draw)
        {
            Draw();
        }
        else if (currentDrawState == DrawState.Erase)
        {
            Erase();
        }
    }

    private void StartDrawing()
    {
        selectedPlacableObject = objectManagerChannelSO.RaiseGetSelectedPlacableObject();
        currentDrawState = DrawState.Draw;
    }

    private void EndDrawing()
    {
        currentDrawState = DrawState.Idle;
    }

    private void StartErasing()
    {
        currentDrawState = DrawState.Erase;
    }

    private void EndErasing()
    {
        currentDrawState = DrawState.Idle;
    }

    private void Draw()
    {
        Vector2 clickPosWorld = GetWorldPosition();

        objectPlacementChannelSO.RaisePlaceObject(clickPosWorld, selectedPlacableObject);
    }

    private void Erase()
    {
        Vector2 clickPosInPixels = gridControlInputAction.Grid.MousePos.ReadValue<Vector2>();
        Vector2 clickPosWorld = GetWorldPosition();

        objectPlacementChannelSO.RaiseRemoveObject(clickPosWorld);
    }

    private Vector2 GetWorldPosition()
    {
        Vector2 clickPosInPixels = gridControlInputAction.Grid.MousePos.ReadValue<Vector2>();

        return mainCam.ScreenToWorldPoint(clickPosInPixels);
    }
}
