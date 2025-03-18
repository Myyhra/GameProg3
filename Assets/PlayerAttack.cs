using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public WeaponData weaponData;
    public GameObject weaponHolder;
    public Collider weaponCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        weaponData.EquipWeapon(weaponHolder);
        weaponCollider = weaponHolder.GetComponentInChildren<Collider>();
        weaponCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");

        }
    }
    public void OffWeaponCollider()
    {
        weaponCollider.enabled=false;
    }
    public void OnWeaponCollider()
    {
        weaponCollider.enabled = true;
    }
}
