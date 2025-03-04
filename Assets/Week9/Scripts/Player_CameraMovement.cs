using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Week9
{
    public class Player_CameraMovement : MonoBehaviour, IMouseMovable, ICameraDirection
    {
        [SerializeField] private Player_Input playerInput;
        public float sensitivity = 0.1f;
        private Vector3 _eulerAngles;
        // private IMouseMovable _mouseMovable;
        

        public virtual Vector2 UpdateCamera(Vector2 mouseDelta)
        {
            _eulerAngles += new Vector3(-mouseDelta.y,mouseDelta.x) * sensitivity;
            return transform.eulerAngles = _eulerAngles;
        }

        public Vector3 GetForwardDirection()
        {
            return transform.forward;
        }
    }
}