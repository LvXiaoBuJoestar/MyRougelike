using UnityEngine;

public class FlyCutterLauncher : MonoBehaviour
{
    [SerializeField] float launchInterval = 1.2f;
    [SerializeField] GameObject prefab;
    [SerializeField, Range(0, 100)] int splitProbability = 16;

    Scanner scanner;

    float timer;

    private void Awake()
    {
        scanner = GetComponent<Scanner>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= launchInterval)
        {
            timer -= launchInterval;
            Transform target = scanner.GetNearestTarget();
            if(target != null)
            {
                Shoot(target);
                if(Random.Range(0, 100) < splitProbability)
                {
                    Shoot(target, 30f);
                    Shoot(target, -30f);
                }
            }
        }
    }

    void Shoot(Transform target, float offsetValue = 0)
    {
        FlyCutter flyCutter = Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<FlyCutter>();
        flyCutter.Init(target, offsetValue);
    }
}
