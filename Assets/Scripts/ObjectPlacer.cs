using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    //SOs
    [SerializeField] ObjectPlacementChannelSO objectPlacementChannelSO;
    [SerializeField] GridChannelSO gridChannelSO;

    private void OnEnable()
    {
        objectPlacementChannelSO.EPlaceObject += PlaceObject;
        objectPlacementChannelSO.ERemoveObject += RemoveObject;
    }

    private void OnDisable()
    {
        objectPlacementChannelSO.EPlaceObject -= PlaceObject;
        objectPlacementChannelSO.ERemoveObject -= RemoveObject;
    }

    private void PlaceObject(Vector2 clickPosition, GameObject obj)
    {
        Vector2Int placeCoordinates = gridChannelSO.RaiseGetCoordinatesByPosition(clickPosition);
        Vector2Int gridCoordinates = new Vector2Int(placeCoordinates.x, Mathf.Abs(placeCoordinates.y - 19));
        Vector2Int objectSize = obj.GetComponent<PlacableTile>().GetTileSize();

        //Get Position according to coordinates
        Vector2 placePosition = GetPositionFromCoordinate(placeCoordinates);

        //Check if any object exist at that coordinate
        // GameObject objectAtCoordinate = gridChannelSO.RaiseGetGameObjectByCoordinates(gridCoordinates, objectSize);
        bool validPlacement = gridChannelSO.RaiseCheckValidPlacement(gridCoordinates, objectSize);

        if (validPlacement != true) return;

        //Spawn object at the spawn position
        GameObject instantiatedGO = Instantiate(obj, placePosition, Quaternion.identity);
        PlacableTile thisPlacableTile = instantiatedGO.GetComponent<PlacableTile>();

        //Update the grid
        gridChannelSO.RaiseUpdateGrid(placeCoordinates, thisPlacableTile.GetTileSize(), instantiatedGO);

        //Set the road type
        thisPlacableTile.SetCoordinates(gridCoordinates);
        thisPlacableTile.InitializePlacament();
    }

    private void RemoveObject(Vector2 clickPosition)
    {
        //Get Coordinates
        Vector2Int placeCoordinates = gridChannelSO.RaiseGetCoordinatesByPosition(clickPosition);
        Vector2Int gridCoordinates = new Vector2Int(placeCoordinates.x, Mathf.Abs(placeCoordinates.y - 19));

        //Get GO at that coordinate
        GameObject removableObject = gridChannelSO.RaiseGetGameObjectByCoordinates(gridCoordinates);

        if (removableObject == null) return;

        PlacableTile removablePlacableTime = removableObject.GetComponent<PlacableTile>();

        //Delete GO at that coordinate
        GameObject.Destroy(removableObject);

        //Update the grid
        gridChannelSO.RaiseUpdateGrid(placeCoordinates, removablePlacableTime.GetTileSize(), null);

        //Update the sorrounding tiles
        gridChannelSO.RaiseUpdateNeighbours(gridCoordinates);
    }

    private Vector2 GetPositionFromCoordinate(Vector2Int coordinate)
    {
        return ((Vector2)coordinate * GridData.CellSize + new Vector2(GridData.CellSize, GridData.CellSize) * 0.5f);
    }
}
