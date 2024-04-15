using UnityEngine;

public class DropLoot : MonoBehaviour
{
    [SerializeField] DropRule[] loots;

    public void Drop()
    {
        foreach(var loot in loots)
        {
            if (Random.Range(0, 100) < loot.dropProbability)
                PoolManager.Instance.GetObjectFromPool(loot.lootPrefab, transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0), Quaternion.identity);
        }
    }
}

[System.Serializable]
public class DropRule
{
    public GameObject lootPrefab;
    [Range(0, 100)] public int dropProbability; 
}
