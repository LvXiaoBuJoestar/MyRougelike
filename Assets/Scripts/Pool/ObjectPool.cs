using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    Queue<GameObject> pool;
    GameObject prefab;

    public ObjectPool(GameObject prefab)
    {
        pool = new Queue<GameObject>();
        this.prefab = prefab;
    }

    public GameObject GetObjectFromPool()
    {
        GameObject result = null;

        if (pool.Count > 0 && !pool.Peek().activeSelf)
        {
            result = pool.Dequeue();
            result.SetActive(true);
        }
        else
        {
            result = GameObject.Instantiate(prefab);
        }

        pool.Enqueue(result);
        return result;
    }
}
