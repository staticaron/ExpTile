using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int[,] gridArray;

    [SerializeField] int gridSizeX;
    [SerializeField] int gridSizeY;

    [SerializeField] float cellSize;

    //SOs
    [SerializeField] GridChannelSO gridChannelSO;

    private void Awake()
    {
        gridArray = new int[gridSizeX, gridSizeY];

        //Linking SOs
        gridChannelSO.EPlaceObject += PlaceObjectAtIndex;
    }

    private void PlaceObjectAtIndex(Vector2 clickPosition, int obj_ID)
    {
        Vector2Int coordinates = PositionToCoordinate(clickPosition);

        Debug.Log(coordinates);

        gridArray[coordinates.x, coordinates.y] = obj_ID;
    }

    [ContextMenu("DebugGridValues")]
    private void DebugGrid()
    {
        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                Debug.Log(gridArray[i, j]);
            }
        }
    }

    private Vector2Int PositionToCoordinate(Vector2 click_pos)
    {
        int coorX = (int)(click_pos.x / cellSize);
        int coorY = (int)(click_pos.y / cellSize);

        return new Vector2Int(coorX, coorY);
    }
}
