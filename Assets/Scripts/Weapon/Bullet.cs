using UnityEngine;

public class Bullet : Weapon
{
    [SerializeField] float speed = 8f;
    [SerializeField] float size = 2;
    [SerializeField] float frequency = 180;

    [SerializeField] TrailRenderer trailRenderer;

    Transform parentTransform;
    Vector2 mainDirection;
    Vector2 direction;
    float angle;

    int sign = 1;

    private void Awake()
    {
        parentTransform = transform.parent.transform;
    }

    public void Init(Vector2 direction)
    {
        mainDirection = direction.normalized;
        this.direction = Quaternion.Euler(0, 0, 90 * sign) * mainDirection;
        angle = 0;
        if (Random.Range(0, 100) < 50)
            sign = 1;
        else
            sign = -1;
    }

    private void Update()
    {
        parentTransform.Translate(mainDirection * speed * Time.deltaTime);
        transform.localPosition = Mathf.Sin(angle) * direction * size;
        angle += Mathf.PI * frequency * Time.deltaTime;
    }

    private void OnDisable()
    {
        trailRenderer.Clear();
    }
}
