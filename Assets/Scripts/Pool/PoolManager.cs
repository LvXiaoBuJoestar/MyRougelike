using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    private Dictionary<GameObject, ObjectPool> pools = new Dictionary<GameObject, ObjectPool>();

    public void CreateObjectPool(GameObject prefab)
    {
        ObjectPool pool = new ObjectPool(prefab);
        pools.Add(prefab, pool);
    }

    public GameObject GetObjectFromPool(GameObject prefab)
    {
        if (!pools.ContainsKey(prefab))
            CreateObjectPool(prefab);

        GameObject result = null;
        if(pools.TryGetValue(prefab, out ObjectPool pool)){
            result = pool.GetObjectFromPool();
        }
        return result;
    }

    public GameObject GetObjectFromPool(GameObject prefab, Vector3 position)
    {
        if (!pools.ContainsKey(prefab))
            CreateObjectPool(prefab);

        GameObject result = null;
        if (pools.TryGetValue(prefab, out ObjectPool pool))
        {
            result = pool.GetObjectFromPool();
            result.transform.position = position;
        }
        return result;
    }

    public GameObject GetObjectFromPool(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (!pools.ContainsKey(prefab))
            CreateObjectPool(prefab);

        GameObject result = null;
        if (pools.TryGetValue(prefab, out ObjectPool pool))
        {
            result = pool.GetObjectFromPool();
            result.transform.position = position;
            result.transform.rotation = rotation;
        }
        return result;
    }
}
