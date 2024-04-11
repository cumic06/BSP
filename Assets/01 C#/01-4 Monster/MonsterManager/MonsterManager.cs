using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    MonsterStatManager Stat;
    SpreadTileMap spreadTileMap;

    public virtual void RefrashHp(int damage)
    {
        Stat.Hp = Mathf.Clamp(Stat.Hp, 0, Stat.MaxHp);
        Stat.Hp -= damage;
    }

    public virtual void DestoryMob()
    {
        if (spreadTileMap.isClearMap)
        {
            Destroy(PrefabManager.Instance.MonsterPrefab[0]);
        }
    }
}
