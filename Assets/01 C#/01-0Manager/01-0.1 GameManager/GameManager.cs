using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerStat playerStat;

    private void Awake()
    {
        playerStat = GetComponent<PlayerStat>();
    }
}
