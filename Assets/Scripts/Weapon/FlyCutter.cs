using UnityEngine;

public class FlyCutter : Weapon
{
    private Transform target;
    private float speed = 8f;
    private float offectValue;

    Vector2 direction;

    public void Init(Transform target, float offectValue = 0)
    {
        this.target = target;
        this.offectValue = offectValue;

        direction = target.position - transform.position;
        transform.right = direction;
    }

    private void Update()
    {
        if (target != null)
        {
            direction = (target.position - transform.position).normalized;
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0, offectValue));
        }
        Move();
    }

    void Move()
    {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
    }
}
