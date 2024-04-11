using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Goblin : MonsterManager
{
    public override void RefrashHp(int damage)
    {
        base.RefrashHp(damage);
    }
}
