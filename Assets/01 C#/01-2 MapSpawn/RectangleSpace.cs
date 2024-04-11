using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleSpace : MonoBehaviour
{
    public Vector2Int leftDown;
    public int width;//≥–¿Ã
    public int height;//≥Ù¿Ã

    public RectangleSpace(Vector2Int leftDown, int width, int height)
    {
        this.leftDown = leftDown;
        this.width = width;
        this.height = height;
    }

    public Vector2Int Center()
    {
        return new Vector2Int(((leftDown.x * 2) + width - 1) / 2, ((leftDown.y * 2) + height - 1) / 2);
    }

    public Vector2Int RandomMopPos()
    {
        return new Vector2Int(((leftDown.x * 2) + width - 2) / 2, ((leftDown.y * 2) + height - 2) / 2);
    }
}
