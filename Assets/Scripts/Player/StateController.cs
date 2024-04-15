using UnityEngine;

public class StateController : MonoBehaviour, IHealth
{
    public StateBar healthBar;
    public StateBar expBar;

    [SerializeField] int maxHealth = 100;
    int health;

    [SerializeField] int maxExp = 40;
    int exp = 0;

    private void Start()
    {
        health = maxHealth;
        healthBar.InitBar(health, maxHealth);
        expBar.InitBar(exp, maxExp);
    }

    public void ChangeHealth(int value)
    {
        health += value;
        if (health > maxHealth)
            health = maxHealth;
        else if (health <= 0)
        {
            health = 0;
            Die();
        }
        healthBar.UpdateBar(health, maxHealth);
    }

    private void Die()
    {
        Debug.Log("Die........................");
    }

    public void AddExp(int value)
    {
        exp += value;
        if(exp >= maxExp)
        {
            exp -= maxExp;
            Upgrade();
        }
        expBar.UpdateBar(exp, maxExp);
    }

    private void Upgrade()
    {
        Debug.Log("Upgrade........................");
    }
}
