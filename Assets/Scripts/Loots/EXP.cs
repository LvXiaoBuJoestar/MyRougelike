using UnityEngine;

public class EXP : LootBase
{
    [SerializeField] int value = 2;

    protected override void OnDrop(Collider2D collision)
    {
        collision.GetComponent<StateController>().AddExp(value);
    } 
}
