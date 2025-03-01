using UnityEngine;

namespace Week9
{


    public class Player_Interactable : MonoBehaviour, IInteractable
    {
        public Transform HoldTransform;
        private Rigidbody rb;
        void Awake()
        {
            if (HoldTransform == null)
            {
                GameObject holdObject = GameObject.Find("HoldObjectlocation");
                if (holdObject != null)
                {
                    HoldTransform = holdObject.transform;
                }
            }
        }

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        public void Interact()
        {
            Debug.Log("Interacted");

            if (HoldTransform != null)
            {
                transform.parent = HoldTransform;
                transform.position = HoldTransform.position;
                rb.useGravity = false;
                rb.isKinematic = true;
                UIManager.Instance.Pickup.SetActive(false);
                UIManager.Instance.Drop.SetActive(true);
            }
        }

        public void Drop()
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.useGravity = true;
            UIManager.Instance.Pickup.SetActive(false);
            UIManager.Instance.Drop.SetActive(false);
        }
    }
}