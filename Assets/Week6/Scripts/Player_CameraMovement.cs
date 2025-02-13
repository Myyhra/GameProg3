using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Week6
{
    public class Player_CameraMovement : MonoBehaviour
    {
        [SerializeField] private Player_Input playerInput;
        public float sensitivity = 0.1f;
        private Vector3 _eulerAngles;

        public void Awake()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            UpdateRotation(playerInput);
        }
        public void UpdateRotation(Player_Input input)
        {
            //use if want the method the occur from the player_input script
            // _eulerAngles += new Vector2(-input.look.y,input.look.x ) * sensitivity;
            _eulerAngles += new Vector3(-input.cameraInput.look.y,input.cameraInput.look.x ) * sensitivity;
            transform.eulerAngles = _eulerAngles;
        }
    }
}