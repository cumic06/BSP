using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [Header("Ã¼·Â")]
    [SerializeField] private int hp;
    public int Hp
    {
        get => hp;
        set
        {
            hp = Hp;
        }
    }
    [SerializeField] private int maxHp;
    public int MaxHp
    {
        get => maxHp;
        set
        {
            maxHp = MaxHp;
        }
    }

    [SerializeField] private int damage;
    public int Damage => damage;
}
