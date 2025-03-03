using UnityEngine;

namespace Week9
{
    
    public class Player_GravityGun_Attack : MonoBehaviour, IAttackable, IRayTest
    {
        [SerializeField]private GameObject holdObject;
        public Transform holdObjectTransform;
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
            if (holdObject != null)
            {
                /*Rigidbody rb = holdObject.GetComponent<Rigidbody>();
                holdObject.transform.SetParent(null);
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.AddForce(transform.forward * 10f, ForceMode.Impulse); // Example throw force
                }*/
                Debug.Log("Throw Object: " + holdObject.name);
                holdObject = null;
            }
            else
            {
                Debug.Log("No object is being held.");
            }
        }

        public void AlternateAttack()
        {
            // GameObject mightHoldingObject = holdObject;
            if (holdObject != null)
            {
                Debug.Log("Holding " + holdObject.name + " Object");
            }
            else
            {
                Debug.Log("No object is being held.");
            }
            
            /*holdObject.transform.SetParent(holdObjectTransform);
            holdObject.transform.localPosition = Vector3.zero;          //REFER TO THE GRAVITY GUN TUTORIAL IN YOUTUBE
            Rigidbody Orb = holdObject.GetComponent<Rigidbody>();
            Orb.isKinematic = true;
            Orb.useGravity = false;*/
        }

        public void RayTest(RaycastHit hit)
        {
            if (hit.collider.gameObject.CompareTag("Gravitable"))
            {
                holdObject = hit.collider.gameObject;
                Debug.Log("Gravitate " + hit.collider.gameObject.name);
            }
        }
    }
}