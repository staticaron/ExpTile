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
    }
}
