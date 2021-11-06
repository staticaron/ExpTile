using UnityEngine;

public class NeighbourData
{
    public bool up = false;
    public bool down = false;
    public bool left = false;
    public bool right = false;
}

public enum RoadBlockType
{
    None, UpDownOneWay, LeftRightOneWay, LeftDownAngleWay, RightDownAngleWay, LeftUpAngleWay, RightUpAngleWay, LeftRightUpTriway, LeftRightDownTriway, LeftUpDownTriway, RightUpDownTriway, AllDirectionalFourWay
}

public class RoadPiece : MonoBehaviour
{
    public RoadBlockType currentRoadType = RoadBlockType.None;

    [SerializeField] Sprite noneDirectionalRoad;
    [SerializeField] Sprite allDirectionalFourWay;
    [SerializeField] Sprite upDownRoadStraight;
    [SerializeField] Sprite leftRightRoadStraight;
    [SerializeField] Sprite leftDownRoadAngle;
    [SerializeField] Sprite rightDownRoadAngle;
    [SerializeField] Sprite leftUpRoadAngle;
    [SerializeField] Sprite rightUpRoadAngle;
    [SerializeField] Sprite leftRightUpTriway;
    [SerializeField] Sprite leftRightDownTriway;
    [SerializeField] Sprite leftUpDownTriway;
    [SerializeField] Sprite rightUpDownTriway;

    [SerializeField] SpriteRenderer thisRenderer;

    private Vector2Int coordinates;

    //SOs
    [SerializeField] GridChannelSO gridChannelSO;

    private void Awake()
    {
        //References
        thisRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateSprite()
    {
        //Check for the sorrounding tiles and update accordingly
        NeighbourData neighbourData = gridChannelSO.RaiseGetNeighbourDataFromCoordinates(coordinates);

        RoadBlockType prevRoadBlockType = currentRoadType;

        Sprite spriteToSet = GetSpriteFromNeighbourData(neighbourData);

        thisRenderer.sprite = spriteToSet;

        if (currentRoadType != prevRoadBlockType)
        {
            gridChannelSO.RaiseUpdateNeighbours(coordinates);
        }
    }

    //Called when road tile is created to set its coordinates
    public void SetCoordinates(Vector2Int coordinates)
    {
        this.coordinates = coordinates;
    }

    private Sprite GetSpriteFromNeighbourData(NeighbourData data)
    {
        if (data.left == true && data.right == false)
        {
            if (data.up == true && data.down == false)
            {
                currentRoadType = RoadBlockType.LeftUpAngleWay;
                return leftUpRoadAngle;
            }
            else if (data.up == false && data.down == true)
            {
                currentRoadType = RoadBlockType.LeftDownAngleWay;
                return leftDownRoadAngle;
            }
            else if (data.up == true && data.down == true)
            {
                currentRoadType = RoadBlockType.LeftUpDownTriway;
                return leftUpDownTriway;
            }
            else if (data.up == false && data.down == false)
            {
                currentRoadType = RoadBlockType.LeftRightOneWay;
                return leftRightRoadStraight;
            }
        }
        if (data.right == true && data.left == false)
        {
            if (data.up == true && data.down == false)
            {
                currentRoadType = RoadBlockType.RightUpAngleWay;
                return rightUpRoadAngle;
            }
            else if (data.up == false && data.down == true)
            {
                currentRoadType = RoadBlockType.RightDownAngleWay;
                return rightDownRoadAngle;
            }
            else if (data.up == true && data.down == true)
            {
                currentRoadType = RoadBlockType.RightUpDownTriway;
                return rightUpDownTriway;
            }
            else if (data.up == false && data.down == false)
            {
                currentRoadType = RoadBlockType.LeftRightOneWay;
                return leftRightRoadStraight;
            }
        }
        if (data.right == true && data.left == true)
        {
            if (data.up == false && data.down == false)
            {
                currentRoadType = RoadBlockType.LeftRightOneWay;
                return leftRightRoadStraight;
            }
        }
        if (data.up == true && data.down == false)
        {
            if (data.left == true && data.right == false)
            {
                currentRoadType = RoadBlockType.LeftUpAngleWay;
                return leftUpRoadAngle;
            }
            else if (data.left == false && data.right == true)
            {
                currentRoadType = RoadBlockType.RightUpAngleWay;
                return rightUpRoadAngle;
            }
            else if (data.left == true && data.right == true)
            {
                currentRoadType = RoadBlockType.LeftRightUpTriway;
                return leftRightUpTriway;
            }
            else if (data.left == false && data.right == false)
            {
                currentRoadType = RoadBlockType.UpDownOneWay;
                return upDownRoadStraight;
            }
        }
        if (data.up == false && data.down == true)
        {
            if (data.left == true && data.right == false)
            {
                currentRoadType = RoadBlockType.LeftDownAngleWay;
                return leftDownRoadAngle;
            }
            else if (data.left == false && data.right == true)
            {
                currentRoadType = RoadBlockType.RightDownAngleWay;
                return rightDownRoadAngle;
            }
            else if (data.left == true && data.right == true)
            {
                currentRoadType = RoadBlockType.LeftRightDownTriway;
                return leftRightDownTriway;
            }
            else if (data.left == false && data.right == false)
            {
                currentRoadType = RoadBlockType.UpDownOneWay;
                return upDownRoadStraight;
            }
        }
        if (data.up == true && data.down == true)
        {
            if (data.left == false && data.right == false)
            {
                currentRoadType = RoadBlockType.UpDownOneWay;
                return upDownRoadStraight;
            }
            else if (data.left == true && data.right == true)
            {
                currentRoadType = RoadBlockType.AllDirectionalFourWay;
                return allDirectionalFourWay;
            }
        }

        return noneDirectionalRoad;
    }
}
