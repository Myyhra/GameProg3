using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Week9
{
    
    public class Player_GravityGun_Attack : MonoBehaviour, IAttackable, IRayTest
    {
        [SerializeField]private Transform holdObject;
        
        [SerializeField]float throwForce, lerpspeed;
        
        [SerializeField]private Rigidbody detectedRB;
        [FormerlySerializedAs("objectRb")] [SerializeField] private Rigidbody objectRB;
        private ICameraDirection cameraDirection;

        private bool isHolding;
        private bool canHold = true;
     
        public void SetCameraDirection(ICameraDirection cameraDirection)
        {
            this.cameraDirection = cameraDirection;
        }

        void Start()
        {

        }


        void Update()
        {
            if (isHolding && objectRB)
            {
                objectRB.MovePosition(Vector3.Lerp(objectRB.position, holdObject.transform.position, lerpspeed * Time.deltaTime));//When holding
            }
        }

        public void Attack()
        {
            //When holding
            if (objectRB)
            {
                objectRB.isKinematic = false;
                if (cameraDirection != null)
                {
                    Vector3 forward = cameraDirection.GetForwardDirection();
                    isHolding = false;
                    objectRB.AddForce(forward * throwForce, ForceMode.VelocityChange);
                }
                else
                {
                    Debug.LogWarning("cameraDirection is not set; Using default direction");
                    // objectRb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
                }
                objectRB = null;
                Invoke(nameof(StopHolding),0.5f);
                Debug.Log("Throw Object: " + holdObject.name);
            }
            else
            {
                Debug.Log("No object is being held.");
            }
            
            //When just want to push
            if (detectedRB && !isHolding)
            {
                detectedRB.isKinematic = false;
                if (cameraDirection != null)
                {
                    Vector3 forward = cameraDirection.GetForwardDirection();
                    isHolding = false;
                    detectedRB.AddForce(forward * throwForce, ForceMode.VelocityChange);
                }
                else
                {
                    Debug.LogWarning("cameraDirection is not set; Using default direction");
                    // DetectedRb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
                }
                detectedRB = null;
                Invoke(nameof(StopHolding),0.5f);
                Debug.Log("Pushing Object: " + holdObject.name);
            }
            else
            {
                Debug.Log("No object To Push.");
            }
        }

        public void AlternateAttack()
        {
            if (detectedRB)
            {
                objectRB = detectedRB;
                objectRB.isKinematic = true;
                isHolding = true;
                canHold = false;
                Debug.Log("Holding " + holdObject.name + " Object");
            }
            else
            {
                Debug.Log("No object is being held.");
            }
            
        }

        public void RayTest(RaycastHit hit)
        {
            /*if (hit.collider.CompareTag("Gravitable")&& canHold )
            {
                // StartCoroutine(WaitForHolding());
                grabbedRb = hit.collider.gameObject.GetComponent<Rigidbody>();
                Debug.Log("Gravitate " + hit.collider.gameObject.name);
            }*/

            if (hit.collider == null || !hit.collider.gameObject.CompareTag("Gravitable") || !canHold)
            {
                detectedRB = null;
                return;
            }
            detectedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
            Debug.Log("Gravitate " + hit.collider.gameObject.name);


        }

        void StopHolding()
        {
            // yield return new WaitForSeconds(0.5f);
            canHold = true;
        }

        IEnumerator WaitForHolding()
        {
            yield return new WaitUntil(() => detectedRB == null);
        }
        


    }
}