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
        //Get coordinates
        Vector2Int placeCoordinates = gridChannelSO.RaiseGetCoordinatesByPosition(clickPosition);
        Vector2Int gridCoordinates = new Vector2Int(placeCoordinates.x, Mathf.Abs(placeCoordinates.y - 19));

        //Get Position according to coordinates
        Vector2 placePosition = GetPositionFromCoordinate(placeCoordinates);

        //Check if any object exist at that coordinate
        GameObject objectAtCoordinate = gridChannelSO.RaiseGetGameObjectByCoordinates(gridCoordinates);

        if (objectAtCoordinate != null) return;

        //Spawn object at the spawn position
        GameObject instantiatedGO = Instantiate(obj, placePosition, Quaternion.identity);

        //Update the grid
        gridChannelSO.RaiseUpdateGrid(placeCoordinates, instantiatedGO);

        //Set the road type
        RoadPiece thisRoadPiece = instantiatedGO.GetComponent<RoadPiece>();
        thisRoadPiece.SetCoordinates(gridCoordinates);
        thisRoadPiece.UpdateSprite();
    }

    private void RemoveObject(Vector2 clickPosition)
    {
        //Get Coordinates
        Vector2Int placeCoordinates = gridChannelSO.RaiseGetCoordinatesByPosition(clickPosition);
        Vector2Int gridCoordinates = new Vector2Int(placeCoordinates.x, Mathf.Abs(placeCoordinates.y - 19));

        //Get GO at that coordinate
        GameObject removableObject = gridChannelSO.RaiseGetGameObjectByCoordinates(gridCoordinates);

        //Check if object is availible at that coordinate
        if (removableObject == null) return;

        //Delete GO at that coordinate
        GameObject.Destroy(removableObject);

        //Update the grid
        gridChannelSO.RaiseUpdateGrid(placeCoordinates, null);
    }

    private Vector2 GetPositionFromCoordinate(Vector2Int coordinate)
    {
        return ((Vector2)coordinate * GridData.CellSize + new Vector2(GridData.CellSize, GridData.CellSize) * 0.5f);
    }
}
