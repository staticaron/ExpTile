using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    //SOs
    [SerializeField] ObjectPlacementChannelSO objectPlacementChannelSO;

    private void Start()
    {
        objectPlacementChannelSO.EPlaceObject += PlaceObject;
    }

    private void PlaceObject(Vector2Int coordinate, int obj_id)
    {
        Vector2 placePosition = GetPositionFromCoordinate(coordinate);

        Debug.Log(coordinate);
        Debug.Log(placePosition);

        GameObject instantiatedObj = Instantiate(GetGameObjectByID(obj_id), placePosition, Quaternion.identity);
    }

    private Vector2 GetPositionFromCoordinate(Vector2Int coordinate)
    {
        return ((Vector2)coordinate * GridData.CellSize + new Vector2(GridData.CellSize, GridData.CellSize) * 0.5f);
    }

    private GameObject GetGameObjectByID(int obj_id)
    {
        return objects[obj_id];
    }
}
