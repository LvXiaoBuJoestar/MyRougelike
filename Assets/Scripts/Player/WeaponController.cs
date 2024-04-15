using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject weaponLauncher;

    private void OnEnable()
    {
        AddWeapon();
    }

    public void AddWeapon()
    {
        Instantiate(weaponLauncher, transform);
    }
}
