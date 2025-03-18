using UnityEngine;

[CreateAssetMenu(fileName =" New Weapon", menuName = "Weapons/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject weaponPrefab;
    public int damage;
    
    public void EquipWeapon(GameObject playerHand)
    {
        GameObject weaponInstance = Instantiate(weaponPrefab,playerHand.transform);
        weaponInstance.transform.localPosition = Vector3.zero;
        weaponInstance.transform.localRotation = Quaternion.identity;

    }
}
