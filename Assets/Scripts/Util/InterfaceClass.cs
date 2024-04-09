public interface IAutoDestroy
{
    void AutoDestroy(float destroyTime);
}

public interface IHealth
{
    int maxHealth { get; set; }
    int health { get; set; }
    void ChangeHealth(int value);
    void Die();
}