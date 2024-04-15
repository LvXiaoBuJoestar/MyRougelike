using UnityEngine;

public class WeaponLauncher : MonoBehaviour
{
    protected WeaponData weaponData;
    protected GameObject prefab;

    [HideInInspector] public int level = 1;

    public void Init(WeaponData weaponData)
    {
        this.weaponData = weaponData;
        prefab = weaponData.prefab;

        Weapon weapon = prefab.GetComponent<Weapon>();
        if (weapon != null)
            weapon.weaponData = weaponData;
        else
            prefab.GetComponentInChildren<Weapon>().weaponData = weaponData;
    }

    public virtual void LevelUp()
    {

    }
}
