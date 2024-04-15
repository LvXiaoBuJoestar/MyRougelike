using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] int startWeapon = 0;

    private void Start()
    {
        AddWeapon(startWeapon);
    }

    public void AddWeapon(int id)
    {
        WeaponData weaponData = WeaponManager.Instance.GetWeaponData(id);
        WeaponLauncher weaponLauncher = Instantiate(weaponData.weaponLauncher, transform).GetComponent<WeaponLauncher>();
        weaponLauncher.Init(weaponData);
    }
}
