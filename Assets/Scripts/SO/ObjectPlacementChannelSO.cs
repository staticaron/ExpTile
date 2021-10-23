using UnityEngine;

[CreateAssetMenu(fileName = "ObjectPlacementChannelSO", menuName = "ObjectPlacementChannelSO", order = 0)]
public class ObjectPlacementChannelSO : ScriptableObject
{
    public delegate void PlaceObject(Vector2Int coordinates, int objID);
    public event PlaceObject EPlaceObject;

    public void RaisePlaceObject(Vector2Int coordinates, int objID)
    {
        if (EPlaceObject == null)
        {
            Debug.Log("No one is there to place objects");
        }
        else
        {
            EPlaceObject(coordinates, objID);
        }
    }
}
