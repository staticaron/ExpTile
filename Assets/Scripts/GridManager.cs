using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int[,] gridArray;

    //SOs
    [SerializeField] GridChannelSO gridChannelSO;
    [SerializeField] ObjectPlacementChannelSO objectPlacementChannelSO;

    private void Awake()
    {
        gridArray = new int[GridData.GridSizeX, GridData.GridSizeY];

        //Linking SOs
        gridChannelSO.EUpdateGrid += PlaceObjectAtIndex;
    }

    private void PlaceObjectAtIndex(Vector2 clickPosition, int obj_iD)
    {
        Vector2Int coordinates = PositionToCoordinate(clickPosition); //Get coordinates out of position vector

        Debug.Log(coordinates);

        gridArray[coordinates.x, coordinates.y] = obj_iD; //Update the grid

        objectPlacementChannelSO.RaisePlaceObject(coordinates, obj_iD); //Place the object
    }

    [ContextMenu("DebugGridValues")]
    private void DebugGrid()
    {
        for (int i = 0; i < GridData.GridSizeX; i++)
        {
            for (int j = 0; j < GridData.GridSizeY; j++)
            {
                Debug.Log($"({i}, {j}) : {gridArray[i, j]}");
            }
        }
    }

    private Vector2Int PositionToCoordinate(Vector2 click_pos)
    {
        int coorX = (int)(click_pos.x / GridData.CellSize);
        int coorY = (int)(click_pos.y / GridData.CellSize);

        return new Vector2Int(coorX, coorY);
    }
}
