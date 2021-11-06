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
        gridChannelSO.EGetNeighbourDataFromCoordinates += GetNeighbourDataFromCoordinates;
        gridChannelSO.EUpdateNeighbours += UpdateNeighbourAtCoordinates;
    }

    private void OnDisable()
    {
        //Unlinking SOs
        gridChannelSO.EGetGameObjectByCoordinates -= GetGameObjectByCoordinates;
        gridChannelSO.EGetCoordinatesByPosition -= PositionToCoordinate;
        gridChannelSO.EUpdateGrid -= UpdateGrid;
        gridChannelSO.EGetNeighbourDataFromCoordinates -= GetNeighbourDataFromCoordinates;
        gridChannelSO.EUpdateNeighbours -= UpdateNeighbourAtCoordinates;
    }

    private Vector2Int PositionToCoordinate(Vector2 click_pos)
    {
        int coorX = (int)(click_pos.x / GridData.CellSize);
        int coorY = (int)(click_pos.y / GridData.CellSize);

        return new Vector2Int(coorX, coorY);
    }

    private GameObject GetGameObjectByCoordinates(Vector2Int coordinates)
    {
        try
        {
            return gridArray[coordinates.x, coordinates.y];
        }
        catch
        {
            return null;
        }
    }

    private void UpdateGrid(Vector2Int coordinates, GameObject obj)
    {
        coordinates = new Vector2Int(coordinates.x, Mathf.Abs(coordinates.y - 19));

        gridArray[coordinates.x, coordinates.y] = obj;
    }

    private NeighbourData GetNeighbourDataFromCoordinates(Vector2Int coordinates)
    {
        NeighbourData neighbourData = new NeighbourData();

        try
        {
            if (gridArray[coordinates.x - 1, coordinates.y] != null) neighbourData.left = true;
        }
        catch (System.Exception e) { Debug.Log("One or more neighbouring tiles doesn't exist"); }
        try
        {
            if (gridArray[coordinates.x + 1, coordinates.y] != null) neighbourData.right = true;
        }
        catch (System.Exception e) { Debug.Log("One or more neighbouring tiles doesn't exist"); }
        try
        {
            if (gridArray[coordinates.x, coordinates.y + 1] != null) neighbourData.down = true;
        }
        catch (System.Exception e) { Debug.Log("One or more neighbouring tiles doesn't exist"); }
        try
        {
            if (gridArray[coordinates.x, coordinates.y - 1] != null) neighbourData.up = true;
        }
        catch (System.Exception e) { Debug.Log("One or more neighbouring tiles doesn't exist"); }

        return neighbourData;
    }

    private void UpdateNeighbourAtCoordinates(Vector2Int coordinates)
    {
        GameObject upObject = GetGameObjectByCoordinates(new Vector2Int(coordinates.x, coordinates.y - 1));
        GameObject downObject = GetGameObjectByCoordinates(new Vector2Int(coordinates.x, coordinates.y + 1));
        GameObject leftObject = GetGameObjectByCoordinates(new Vector2Int(coordinates.x - 1, coordinates.y));
        GameObject rightObject = GetGameObjectByCoordinates(new Vector2Int(coordinates.x + 1, coordinates.y));

        if (upObject != null) upObject.GetComponent<RoadPiece>().UpdateSprite();
        if (downObject != null) downObject.GetComponent<RoadPiece>().UpdateSprite();
        if (leftObject != null) leftObject.GetComponent<RoadPiece>().UpdateSprite();
        if (rightObject != null) rightObject.GetComponent<RoadPiece>().UpdateSprite();
    }

    [ContextMenu("Print Grid")]
    private void PrintGrid()
    {
        string line = default;

        for (int i = 0; i < GridData.GridSizeY; i++)
        {
            for (int j = 0; j < GridData.GridSizeX; j++)
            {
                string value = gridArray[j, i] == null ? "- " : "@";
                line += $"{value}";
            }

            line += '\n';
        }

        Debug.Log(line);
    }
}
