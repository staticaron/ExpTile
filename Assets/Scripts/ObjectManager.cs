using UnityEngine;
using System.Collections.Generic;
using System;

public enum PlaceObjectType
{
    Normal,
    Red,
    Blue
}

[Serializable]
public class PlacableObject
{
    public PlaceObjectType type;
    public GameObject placableObject;
}

public class ObjectManager : MonoBehaviour
{
    [SerializeField] List<PlacableObject> placableObjects;

    [SerializeField] PlaceObjectType selectedObject = PlaceObjectType.Normal;

    //SOs
    [SerializeField] ObjectManagerChannelSO objectManagerChannelSO;

    private void Start()
    {
        objectManagerChannelSO.EGetSelectedPlacableObject += GetSelectedGameObject;
    }

    private void OnDestroy()
    {
        objectManagerChannelSO.EGetSelectedPlacableObject -= GetSelectedGameObject;
    }

    private GameObject GetSelectedGameObject()
    {
        return GetGameObjectByType(selectedObject);
    }

    private GameObject GetGameObjectByType(PlaceObjectType objectType)
    {
        foreach (PlacableObject p in placableObjects)
        {
            if (p.type == objectType)
            {
                return p.placableObject;
            }
        }

        Debug.Log("Requested object was not found");
        return null;
    }
}
