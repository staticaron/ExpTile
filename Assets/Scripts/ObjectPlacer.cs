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
    }

    private void OnDisable()
    {
        objectPlacementChannelSO.EPlaceObject -= PlaceObject;
    }

    private void PlaceObject(Vector2 clickPosition, GameObject obj)
    {
        //Get coordinates
        Vector2Int coordinates = gridChannelSO.RaiseGetCoordinatesByPosition(clickPosition);

        //Get Position according to coordinates
        Vector2 placePosition = GetPositionFromCoordinate(coordinates);

        //Spawn object at the spawn position
        GameObject instantiatedGO = Instantiate(obj, placePosition, Quaternion.identity);

        Debug.Log(instantiatedGO.GetInstanceID());

        //Update the grid
        gridChannelSO.RaiseUpdateGrid(coordinates, instantiatedGO);
    }

    private Vector2 GetPositionFromCoordinate(Vector2Int coordinate)
    {
        return ((Vector2)coordinate * GridData.CellSize + new Vector2(GridData.CellSize, GridData.CellSize) * 0.5f);
    }
}
