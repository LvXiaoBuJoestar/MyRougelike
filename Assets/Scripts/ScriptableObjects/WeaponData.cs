using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "ScriptableObject/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public int id = 0;
    public int damage = 50;
    public int pierce = -1;

    public bool autoDestroy;
    public bool destroyParent;
    public float destroyTime = 5f;
}
