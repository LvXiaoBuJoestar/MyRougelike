using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour, IAutoDestroy
{
    [SerializeField] WeaponData weaponData;

    private int pierce = -1;

    void OnEnable()
    {
        this.pierce = weaponData.pierce;
        if (weaponData.autoDestroy)
            AutoDestroy(weaponData.destroyTime);
    }

    public void AutoDestroy(float destroyTime)
    {
        StartCoroutine(DestroyCoroutine(destroyTime));
    }
    IEnumerator DestroyCoroutine(float destroyTime)
    {
        float timer = 0f;
        while (timer < destroyTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        DestroyFunction();
    }
    private void DestroyFunction()
    {
        if (weaponData.destroyParent)
            transform.parent.gameObject.SetActive(false);
        else
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IHealth>(out IHealth health))
        {
            health.ChangeHealth(-weaponData.damage);

            if (this.pierce == 0)
                DestroyFunction();
            else if (this.pierce > 0)
                this.pierce--;
        }
    }
}
