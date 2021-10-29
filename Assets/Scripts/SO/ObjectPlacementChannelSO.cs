using UnityEngine;

[CreateAssetMenu(fileName = "ObjectPlacementChannelSO", menuName = "ObjectPlacementChannelSO", order = 0)]
public class ObjectPlacementChannelSO : ScriptableObject
{
    public delegate void PlaceObject(Vector2 position, GameObject obj);
    public event PlaceObject EPlaceObject;

    public delegate void RemoveObject(Vector2 position);
    public event RemoveObject ERemoveObject;

    public void RaisePlaceObject(Vector2 position, GameObject obj)
    {
        if (EPlaceObject == null)
        {
            Debug.Log("No one is there to place objects");
        }
        else
        {
            EPlaceObject(position, obj);
        }
    }

    public void RaiseRemoveObject(Vector2 position)
    {
        if (ERemoveObject == null)
        {
            Debug.Log("Error raising RemoveObject(), check if ObjectPlacer exist");
        }
        else
        {
            ERemoveObject(position);
        }
    }
}
