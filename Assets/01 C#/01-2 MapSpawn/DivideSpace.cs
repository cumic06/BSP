using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideSpace : MonoBehaviour
{
    public int totalWidth;//전체공간넓이
    public int totalHeight;//전체공간높이
    [SerializeField] private int minWidth;//최소 넓이
    [SerializeField] private int minHeight;//최소 높이

    public RectangleSpace totalSpace;// 전체공간

    public List<RectangleSpace> spaceList;

    public void DivideRoom(RectangleSpace space)
    {
        if (space.height >= minHeight * 2 && space.width >= minWidth * 2)
        {
            if (Random.Range(0, 2) < 1)
            {
                RectangleSpace[] spaces = DivideHorizontal(space);
                DivideRoom(spaces[0]);
                DivideRoom(spaces[1]);
            }
            else
            {
                RectangleSpace[] spaces = DivideVertical(space);
                DivideRoom(spaces[0]);
                DivideRoom(spaces[1]);
            }
        }
        else if (space.height < minHeight * 2 && space.width >= minWidth * 2)
        {
            RectangleSpace[] spaces = DivideVertical(space);
            DivideRoom(spaces[0]);
            DivideRoom(spaces[1]);
        }
        else if (space.height >= minHeight * 2 && space.width < minWidth * 2)
        {
            RectangleSpace[] spaces = DivideHorizontal(space);
            DivideRoom(spaces[0]);
            DivideRoom(spaces[1]);
        }
        else
        {
            spaceList.Add(space);
        }
    }

    private RectangleSpace[] DivideHorizontal(RectangleSpace space)
    {
        int newSpace1Height = minHeight + Random.Range(0, space.height - minHeight * 2 + 1);
        RectangleSpace newSpace1 = new RectangleSpace(space.leftDown, space.width, newSpace1Height);

        int newSpace2Height = space.height - newSpace1Height;
        Vector2Int newSpaceLeftDown = new Vector2Int(space.leftDown.x, space.leftDown.y + newSpace1Height);
        RectangleSpace newSpace2 = new RectangleSpace(newSpaceLeftDown, space.width, newSpace2Height);

        RectangleSpace[] spaces = new RectangleSpace[2];
        spaces[0] = newSpace1;
        spaces[1] = newSpace2;
        return spaces;
    }

    private RectangleSpace[] DivideVertical(RectangleSpace space)
    {
        int newSpace1Width = minWidth + Random.Range(0, space.width - minWidth * 2 + 1);
        RectangleSpace newSpace1 = new RectangleSpace(space.leftDown, newSpace1Width, space.height);

        int newSpace2Width = space.width - newSpace1Width;
        Vector2Int newSpaceLeftDown = new Vector2Int(space.leftDown.x + newSpace1Width, space.leftDown.y);
        RectangleSpace newSpace2 = new RectangleSpace(newSpaceLeftDown, newSpace2Width, space.height);

        RectangleSpace[] spaces = new RectangleSpace[2];
        spaces[0] = newSpace1;
        spaces[1] = newSpace2;
        return spaces;
    }
}
