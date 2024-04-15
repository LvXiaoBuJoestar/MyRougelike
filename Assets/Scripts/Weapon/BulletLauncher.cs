using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float launchInterval = 1f;

    float timer;

    private void Start()
    {
        //PoolManager.Instance.CreateObjectPool(prefab);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= launchInterval)
        {
            timer -= launchInterval;

            Shoot(Vector2.left);
            Shoot(Vector2.right);
        }
    }

    void Shoot(Vector2 direction)
    {
        GameObject go = PoolManager.Instance.GetObjectFromPool(prefab, transform.position, Quaternion.identity);
        go.GetComponentInChildren<Bullet>().Init(direction);
    }
}
