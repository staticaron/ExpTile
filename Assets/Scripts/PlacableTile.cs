using UnityEngine;

public class PlacableTile : MonoBehaviour
{
    [SerializeField] protected Vector2Int coordinates;
    [SerializeField] protected Vector2Int size;

    public void SetCoordinates(Vector2Int _coordinates)
    {
        this.coordinates = _coordinates;
    }

    public virtual void InitializePlacament()
    {
        Debug.Log("This method was not initialized");
    }

    public Vector2Int GetTileSize()
    {
        return this.size;
    }

    public Vector2Int GetTileCoordinates()
    {
        return coordinates;
    }
}
