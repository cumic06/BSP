using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpreadTileMap : MonoBehaviour
{
    private MakeRandomMap makeRandomMap;
    [SerializeField] private Tilemap TileMapFloor;
    [SerializeField] private Tilemap TileMapWall;
    [SerializeField] private TileBase FloorTile;
    [SerializeField] private TileBase WallTile;

    //Action 언제 써야하는지 혁철 선배한테 꼭 물어볼 것
    //Action action;

    //private void Awake()
    //{
    //    action += () => monsterManager.DestoryMob();
    //}
    public bool isClearMap;

    public void SpreadFloorMap(HashSet<Vector2Int> positions)
    {
        SpreadObject(positions, TileMapFloor, FloorTile);
    }

    public void SpreadWallMap(HashSet<Vector2Int> positions)
    {
        SpreadObject(positions, TileMapWall, WallTile);
    }

    private void SpreadObject(HashSet<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            tilemap.SetTile((Vector3Int)position, tile);
        }
    }

    public void ClearAllTiles()
    {
        isClearMap = true;
        TileMapFloor.ClearAllTiles();
        TileMapWall.ClearAllTiles();
        //action.Invoke();
    }
}
