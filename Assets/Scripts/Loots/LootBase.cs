using UnityEngine;

public class LootBase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnDrop(collision);
        gameObject.SetActive(false);
    }

    protected virtual void OnDrop(Collider2D collision)
    {

    } 
}
