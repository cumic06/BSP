using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRandomMap : MonoBehaviour
{
    [SerializeField] private int distance;//거리
    [SerializeField] private int minRoomWidth;//방 최소 넓이
    [SerializeField] private int minRoomHeight;//방 최소 높이
    [SerializeField] private DivideSpace divideSpace;//나눌 공간
    [SerializeField] private SpreadTileMap spreadTileMap;
    [SerializeField] GameObject player;
    [SerializeField] GameObject entrance;

    private HashSet<Vector2Int> floor;
    private HashSet<Vector2Int> wall;

    private void Start()
    {
        StartRandomMap();
    }

    public void StartRandomMap()
    {
        spreadTileMap.ClearAllTiles();
        divideSpace.totalSpace = new RectangleSpace(new Vector2Int(0, 0), divideSpace.totalWidth, divideSpace.totalHeight);
        divideSpace.spaceList = new List<RectangleSpace>();
        floor = new HashSet<Vector2Int>();
        wall = new HashSet<Vector2Int>();
        divideSpace.DivideRoom(divideSpace.totalSpace);
        MakeRandomRooms();

        MakeCorriders();

        MakeWall();

        spreadTileMap.SpreadFloorMap(floor);
        spreadTileMap.SpreadWallMap(wall);

        player.transform.position = (Vector2)divideSpace.spaceList[0].Center();
        entrance.transform.position = (Vector2)divideSpace.spaceList[^1].Center();
        MonsterSpawnManager.Instance.MonsterSpawn(divideSpace.spaceList[^1].RandomMopPos());
    }

    private void MakeRandomRooms()
    {
        foreach (var space in divideSpace.spaceList)
        {
            HashSet<Vector2Int> positions = MakeARandomRectangleRoom(space);
            floor.UnionWith(positions);//UnionWith란 HashSet함수(합집합)
        }
    }

    private HashSet<Vector2Int> MakeARandomRectangleRoom(RectangleSpace space)
    {
        HashSet<Vector2Int> positions = new HashSet<Vector2Int>();
        int width = Random.Range(minRoomWidth, space.width + 1 - distance * 2);
        int height = Random.Range(minRoomHeight, space.height + 1 - distance * 2);
        for (int i = space.Center().x - width / 2; i <= space.Center().x + width / 2; i++)
        {
            for (int j = space.Center().y - height / 2; j < space.Center().y + height / 2; j++)
            {
                positions.Add(new Vector2Int(i, j));
            }
        }
        return positions;
    }

    private void MakeCorriders()
    {
        List<Vector2Int> tempCenters = new List<Vector2Int>();
        foreach (var space in divideSpace.spaceList)
        {
            tempCenters.Add(new Vector2Int(space.Center().x, space.Center().y));
        }
        Vector2Int nextCenter;
        Vector2Int currentCenter = tempCenters[0];
        tempCenters.Remove(currentCenter);

        while (tempCenters.Count != 0)
        {
            nextCenter = ChooseShortesNextCorrider(tempCenters, currentCenter);
            MakeOnCorrider(currentCenter, nextCenter);
            currentCenter = nextCenter;
            tempCenters.Remove(currentCenter);
        }
    }

    private Vector2Int ChooseShortesNextCorrider(List<Vector2Int> tempCenters, Vector2Int previousCenter)
    {
        int n = 0;
        float minLength = float.MaxValue;
        for (int i = 0; i < tempCenters.Count; i++)
        {
            if (Vector2.Distance(previousCenter, tempCenters[i]) < minLength)
            {
                minLength = Vector2.Distance(previousCenter, tempCenters[i]);
                n = i;
            }
        }
        return tempCenters[n];
    }

    private void MakeOnCorrider(Vector2Int currentCenter, Vector2Int nextCenter)
    {
        Vector2Int current = new Vector2Int(currentCenter.x, currentCenter.y);
        Vector2Int next = new Vector2Int(nextCenter.x, nextCenter.y);
        floor.Add(current);
        while (current.x != next.x)
        {
            if (current.x < next.x)
            {
                current.x += 1;
                floor.Add(current);
            }

            else
            {
                current.x -= 1;
                floor.Add(current);
            }
        }
        while (current.y != next.y)
        {
            if (current.y < next.y)
            {
                current.y += 1;
                floor.Add(current);
            }
            else
            {
                current.y -= 1;
                floor.Add(current);
            }
        }
    }

    private void MakeWall()
    {
        foreach (Vector2Int tile in floor)
        {
            HashSet<Vector2Int> boundary = Make3X3Square(tile);
            boundary.ExceptWith(floor);//차집합
            if (boundary.Count != 0)
            {
                wall.UnionWith(boundary);//합집합
            }
        }
    }

    private HashSet<Vector2Int> Make3X3Square(Vector2Int tile)
    {
        HashSet<Vector2Int> boundary = new HashSet<Vector2Int>();
        for (int i = tile.x - 1; i <= tile.x + 1; i++)
        {
            for (int j = tile.y - 1; j <= tile.y + 1; j++)
            {
                boundary.Add(new Vector2Int(i, j));
            }
        }
        return boundary;
    }

}
