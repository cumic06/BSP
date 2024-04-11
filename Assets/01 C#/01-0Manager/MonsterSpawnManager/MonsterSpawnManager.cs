using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoSingleton<MonsterSpawnManager>
{
    public void MonsterSpawn(Vector2Int spawnposition)
    {
        Instantiate(PrefabManager.Instance.MonsterPrefab[0], (Vector2)spawnposition, Quaternion.identity);
    }
}
