using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] float speed = 3f;

    Rigidbody2D rb;

    Transform target;
    Vector2 direction;

    public int maxHealth { get; set; }
    public int health { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = GameManager.Instance.Player.transform;
        maxHealth = 1000;
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        rb.velocity = Vector2.zero;
    }

    public void ChangeHealth(int value)
    {
        health += value;
        if (health > maxHealth)
            health = maxHealth;
        else if (health <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
