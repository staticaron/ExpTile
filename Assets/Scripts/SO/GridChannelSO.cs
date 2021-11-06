using UnityEngine;

[CreateAssetMenu(fileName = "GridChannelSO", menuName = "GridChannelSO", order = 0)]
public class GridChannelSO : ScriptableObject
{
    public delegate GameObject GetGameObjectByCoordinates(Vector2Int coordinates);
    public event GetGameObjectByCoordinates EGetGameObjectByCoordinates;

    public delegate void UpdateGrid(Vector2Int coordinates, GameObject obj);
    public event UpdateGrid EUpdateGrid;

    public delegate Vector2Int GetCoordinatesByPosition(Vector2 position);
    public event GetCoordinatesByPosition EGetCoordinatesByPosition;

    public delegate NeighbourData GetNeighbourDataFromCoordinates(Vector2Int coordinates);
    public event GetNeighbourDataFromCoordinates EGetNeighbourDataFromCoordinates;

    public delegate void UpdateNeighbours(Vector2Int gridCoordinates);
    public event UpdateNeighbours EUpdateNeighbours;

    public GameObject RaiseGetGameObjectByCoordinates(Vector2Int coordinates)
    {
        if (EGetGameObjectByCoordinates == null)
        {
            Debug.LogError("Error Raising GetGameObjectByCoordinates(), check if GridManager exist");
            return null;
        }
        else
        {
            return EGetGameObjectByCoordinates(coordinates);
        }
    }

    public void RaiseUpdateGrid(Vector2Int coordinates, GameObject obj)
    {
        if (EUpdateGrid == null)
        {
            Debug.Log("Error Raising UpdateGrid(), check if Grid Manager exist");
        }
        else
        {
            EUpdateGrid(coordinates, obj);
        }
    }

    public Vector2Int RaiseGetCoordinatesByPosition(Vector2 position)
    {
        if (EGetCoordinatesByPosition == null)
        {
            Debug.Log("Error raising GetCoordinatesByPosition(), check if GridManager exist");
            return Vector2Int.zero;
        }
        else
        {
            return EGetCoordinatesByPosition(position);
        }
    }

    public NeighbourData RaiseGetNeighbourDataFromCoordinates(Vector2Int coordinates)
    {
        if (EGetNeighbourDataFromCoordinates == null)
        {
            Debug.Log("Error raising GetNeighbouringDataFromCoordinates, check if gridData exist");
            return null;
        }
        else
        {
            return EGetNeighbourDataFromCoordinates(coordinates);
        }
    }

    public void RaiseUpdateNeighbours(Vector2Int gridCoordinates)
    {
        if (EUpdateNeighbours == null)
        {
            Debug.Log("Error raising UpdateNeighbours, check if gridManager exists");
        }
        else
        {
            EUpdateNeighbours(gridCoordinates);
        }
    }
}