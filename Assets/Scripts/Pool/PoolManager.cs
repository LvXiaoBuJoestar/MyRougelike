using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    private Dictionary<GameObject, ObjectPool> pools = new Dictionary<GameObject, ObjectPool>();

    public void CreateObjectPool(GameObject prefab)
    {
        if (pools.ContainsKey(prefab))
            return;

        ObjectPool pool = new ObjectPool(prefab);
        pools.Add(prefab, pool);
    }

    public GameObject GetObjectFromPool(GameObject prefab)
    {
        GameObject result = null;
        if(pools.TryGetValue(prefab, out ObjectPool pool)){
            result = pool.GetObjectFromPool();
        }
        return result;
    }

    public GameObject GetObjectFromPool(GameObject prefab, Vector3 position)
    {
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
