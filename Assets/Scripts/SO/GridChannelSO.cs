using UnityEngine;

[CreateAssetMenu(fileName = "GridChannelSO", menuName = "GridChannelSO", order = 0)]
public class GridChannelSO : ScriptableObject
{
    public delegate void PlaceObject(Vector2 clickPos, int obj_ID);
    public event PlaceObject EPlaceObject;

    public void RaisePlaceObject(Vector2 clickPos, int obj_ID)
    {
        if (EPlaceObject == null)
        {
            Debug.Log("No one is Placeing Objects");
        }
        else
        {
            EPlaceObject(clickPos, obj_ID);
        }
    }
}