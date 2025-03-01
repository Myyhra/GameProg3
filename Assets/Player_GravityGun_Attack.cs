using UnityEngine;

namespace Week9
{
    
    public class Player_GravityGun_Attack : MonoBehaviour, IAttackable
    {
        void Awake()
        {

        }

        void Start()
        {

        }


        void Update()
        {

        }

        public void Attack()
        {
            Debug.Log("Throw Object");
        }

        public void AlternateAttack()
        {
            Debug.Log("Hold Object");
        }
    }
}