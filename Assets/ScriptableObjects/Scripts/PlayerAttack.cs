using UnityEngine;

namespace ScriptableObjects
{
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
            weaponCollider = weaponHolder.GetComponentInChildren<Collider>();
            weaponData.EquipWeapon(weaponHolder);
            weaponCollider.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Attack");

            }
        }
    }
}
