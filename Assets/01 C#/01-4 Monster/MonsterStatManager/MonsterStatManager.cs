using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatManager : MonoBehaviour
{
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

    public MonsterType monsterType;

    private void Start()
    {
        Stat();
    }

    private void Stat()
    {
        switch (monsterType)
        {
            case MonsterType.Gobline:
                hp = 100;
                maxHp = 100;
                damage = 10;
                break;
            case MonsterType.BoneKnight:
                hp = 100;
                maxHp = 100;
                damage = 15;
                break;
            case MonsterType.Boss1:
                hp = 500;
                maxHp = 500;
                damage = 30;
                break;
        }
    }
}
