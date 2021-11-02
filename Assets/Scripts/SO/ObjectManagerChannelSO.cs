using UnityEngine;

[CreateAssetMenu(fileName = "ObjectManagerChannelSO", menuName = "ObjectManagerChannelSO", order = 0)]
public class ObjectManagerChannelSO : ScriptableObject
{
    public delegate GameObject GetSelectedPlacableObject();
    public event GetSelectedPlacableObject EGetSelectedPlacableObject;

    public GameObject RaiseGetSelectedPlacableObject()
    {
        if (EGetSelectedPlacableObject == null)
        {
            Debug.Log("Error raising GetSelectedPlacableObject");
            return null;
        }
        else
        {
            return EGetSelectedPlacableObject();
        }
    }
}