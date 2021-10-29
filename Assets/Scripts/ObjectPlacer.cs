using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
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
        Vector2Int coordinates = gridChannelSO.RaiseGetCoordinatesByPosition(clickPosition);

        //Get Position according to coordinates
        Vector2 placePosition = GetPositionFromCoordinate(coordinates);

        //Check if any object exist at that coordinate
        GameObject objectAtCoordinate = gridChannelSO.RaiseGetGameObjectByCoordinates(coordinates);

        if (objectAtCoordinate != null)
        {
            Debug.Log("Bruh, an object already exist there");
            return;
        }

        //Spawn object at the spawn position
        GameObject instantiatedGO = Instantiate(obj, placePosition, Quaternion.identity);

        Debug.Log(instantiatedGO.GetInstanceID());

        //Update the grid
        gridChannelSO.RaiseUpdateGrid(coordinates, instantiatedGO);
    }

    private void RemoveObject(Vector2 clickPosition)
    {
        //Get Coordinates
        Vector2Int coordinates = gridChannelSO.RaiseGetCoordinatesByPosition(clickPosition);

        //Get GO at that coordinate
        GameObject removableObject = gridChannelSO.RaiseGetGameObjectByCoordinates(coordinates);

        //Check if object is availible at that coordinate
        if (removableObject == null)
        {
            Debug.Log("No object exist at that coordinate to remove");
            return;
        }

        //Delete GO at that coordinate
        GameObject.Destroy(removableObject);

        //Update the grid
        gridChannelSO.RaiseUpdateGrid(coordinates, null);
    }

    private Vector2 GetPositionFromCoordinate(Vector2Int coordinate)
    {
        return ((Vector2)coordinate * GridData.CellSize + new Vector2(GridData.CellSize, GridData.CellSize) * 0.5f);
    }
}
