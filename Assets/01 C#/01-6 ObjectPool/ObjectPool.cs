using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    Dictionary<GameObject, Queue<GameObject>> PoolDic = new Dictionary<GameObject, Queue<GameObject>>();

    public void GetObject(GameObject prefab, Vector2 position, Quaternion rotation)
    {
        if (PoolDic.ContainsKey(prefab))
        {
            PoolDic.Add(prefab, new Queue<GameObject>());
        }
    }
}






