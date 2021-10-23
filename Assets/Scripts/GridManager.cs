using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int[,] gridArray;

    [SerializeField] int sizeX;
    [SerializeField] int sizeY;

    private void Awake()
    {
        gridArray = new int[sizeX, sizeY];
    }
}
