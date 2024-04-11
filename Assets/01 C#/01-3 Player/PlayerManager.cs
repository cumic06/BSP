using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerStat playerStat;

    public void RefreshHp(int damage)
    {
        playerStat.Hp -= damage;
    }
}
