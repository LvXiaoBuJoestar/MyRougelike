using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoSingleton<WeaponManager>
{
    [SerializeField] WeaponData[] weaponDatas;

    Dictionary<int, WeaponData> datas;

    protected override void OnAwake()
    {
        datas = new Dictionary<int, WeaponData>();
        foreach(var weaponData in weaponDatas)
        {
            datas.Add(weaponData.id, weaponData);
        }
    }

    public WeaponData GetWeaponData(int id)
    {
        if (datas.TryGetValue(id, out WeaponData weaponData))
            return weaponData;
        return null;
    }
}
