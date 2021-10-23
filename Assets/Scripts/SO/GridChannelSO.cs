using UnityEngine;

[CreateAssetMenu(fileName = "GridChannelSO", menuName = "GridChannelSO", order = 0)]
public class GridChannelSO : ScriptableObject
{
    public delegate void UpdateGrid(Vector2 clickPos, int obj_ID);
    public event UpdateGrid EUpdateGrid;

    public void RaisePlaceObject(Vector2 clickPos, int obj_ID)
    {
        if (EUpdateGrid == null)
        {
            Debug.Log("No grid exist");
        }
        else
        {
            EUpdateGrid(clickPos, obj_ID);
        }
    }
}