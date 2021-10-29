using System;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject[,] gridArray;

    //SOs
    [SerializeField] GridChannelSO gridChannelSO;
    [SerializeField] ObjectPlacementChannelSO objectPlacementChannelSO;

    private void Awake()
    {
        gridArray = new GameObject[GridData.GridSizeX, GridData.GridSizeY];
    }

    private void OnEnable()
    {
        //Linking SOs
        gridChannelSO.EGetGameObjectByCoordinates += GetGameObjectByCoordinates;
        gridChannelSO.EGetCoordinatesByPosition += PositionToCoordinate;
        gridChannelSO.EUpdateGrid += UpdateGrid;
    }

    private void OnDisable()
    {
        //Unlinking SOs
        gridChannelSO.EGetGameObjectByCoordinates -= GetGameObjectByCoordinates;
        gridChannelSO.EGetCoordinatesByPosition -= PositionToCoordinate;
        gridChannelSO.EUpdateGrid -= UpdateGrid;
    }

    [ContextMenu("DebugGridValues")]
    private void DebugGrid()
    {
        string line = default;

        for (int i = 0; i < GridData.GridSizeX; i++)
        {
            //Starts the line
            line += '\n';

            //Enter coordinates in the first line
            for (int j = 0; j < GridData.GridSizeY; j++)
            {
                line += $" ({i}, {j}) ";
            }

            line += '\n';

            //Enter values in the second line
            for (int k = 0; k < GridData.GridSizeY; k++)
            {
                line += $"    {gridArray[i, k]}    ";
            }

        }

        Debug.Log(line);
    }

    private Vector2Int PositionToCoordinate(Vector2 click_pos)
    {
        int coorX = (int)(click_pos.x / GridData.CellSize);
        int coorY = (int)(click_pos.y / GridData.CellSize);

        return new Vector2Int(coorX, coorY);
    }

    private GameObject GetGameObjectByCoordinates(Vector2Int coordinates)
    {
        return gridArray[coordinates.x, coordinates.y];
    }

    private void UpdateGrid(Vector2Int coordinates, GameObject obj)
    {
        gridArray[coordinates.x, coordinates.y] = obj;
        Debug.Log(gridArray[coordinates.x, coordinates.y].GetInstanceID());
    }
}
