using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Week9
{
    public class Player_Camera : MonoBehaviour
    {
        // [SerializeField] private Player_Input playerInput;
        private Camera cam;
        [Header("Interact Ray Settings")]
        [SerializeField] private float rayDist = 10f;
        [SerializeField] private LayerMask gravitableMask;

        public Player_GravityGun_Attack gravityGun;
        //Interfaces
        private IRayTest IrayTest;
        
        // private bool interactHit;
        void Awake()
        {
            cam = GetComponent<Camera>();
            if (cam == null)
            {
                Debug.LogError("Camera component not found on Player_Camera GameObject.");
            }
            if (gravityGun != null)
            {
                IrayTest = gravityGun.GetComponent<IRayTest>();
                if (IrayTest == null)
                {
                    Debug.LogError("gravityGun does not have an IRayTest component.");
                }
            }
            else
            {
                Debug.LogError("gravityGun is not assigned in Player_Camera.");
            }

        }

        void Start()
        {

        }
        void Update()
        {
            if(gravityGun.isActiveAndEnabled)  //Better off in making another script with weapon switching next time
            Raycasting();
        }

        public void Raycasting()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            #if  UNITY_EDITOR
            Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.red);
            #endif
            if (!Physics.Raycast(ray, out var hit, rayDist, gravitableMask)) return;
            // interactHit = hit;
            if (IrayTest != null)
            {
                IrayTest.RayTest(hit);
            }
            else
            {
                Debug.LogWarning("IRayTest is not assigned.");
            }

        }
        
    }
}
