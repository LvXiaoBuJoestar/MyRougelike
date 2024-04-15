using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] float speed = 3f;

    Rigidbody2D rb;

    Transform target;
    Vector2 direction;

    [SerializeField] private int maxHealth = 1000;
    private int health;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = GameManager.Instance.Player.transform;
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

    private void Die()
    {
        GetComponent<DropLoot>().Drop();
        gameObject.SetActive(false);
    }

    float lastTakeDamageTime = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if(Time.time - lastTakeDamageTime > 0.4f)
            {
                lastTakeDamageTime = Time.time;
                collision.transform.GetComponent<IHealth>().ChangeHealth(-20);
            }
        }
    }
}
