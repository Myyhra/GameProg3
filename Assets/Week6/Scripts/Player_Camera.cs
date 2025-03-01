using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Week6
{
    public class Player_Camera : MonoBehaviour
    {
        [SerializeField] private Player_Input playerInput;
        [SerializeField] private Camera cam;
        [Header("Interact Ray Settings")]
        [SerializeField] private float rayDist = 10f;
        [SerializeField] private LayerMask mask;
        private IInteractable IInteractable;
        private bool interactHit;
        void Awake()
        {
            cam = GetComponent<Camera>();
            
        }

        void Start()
        {

        }


        void Update()
        {
            Interact(playerInput.characterInput.interacting);
        }
        // ReSharper disable Unity.PerformanceAnalysis
        public void Interact(bool interact)
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            #if  UNITY_EDITOR
            Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.green);
            #endif

            if (!Physics.Raycast(ray, out var hit, rayDist, mask))
            {
                UIManager.Instance.Pickup.SetActive(false);
                return;
            }
            interactHit = hit.collider.CompareTag("PickUp");
            if (interactHit)
            {
                UIManager.Instance.Pickup.SetActive(true);
            }
            else
            {
                UIManager.Instance.Pickup.SetActive(false);
            }
            

            if (interact)
            {
                Debug.Log("Grabbing Object");
                DetectInteractable(ray);
            }
            else
            {
                DropObject();
                
            }

        }

        public void DetectInteractable(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, rayDist, mask))
            {
                if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
                {
                     IInteractable = interactable;
                     interactable.Interact();
                }
            }
        }

        public void DropObject()
        {
            if (IInteractable != null)
            {
                IInteractable.Drop();
                IInteractable = null; 
            }
        }

       
        
    }
}
