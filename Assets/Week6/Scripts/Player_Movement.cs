using UnityEngine;

namespace Week6
{
    
    [RequireComponent(typeof(Player_Input))]
    [RequireComponent(typeof(CharacterController))]
    public class Player_Movement : MonoBehaviour
    {
        private CharacterController controller;
        private Player_Input input;
        [SerializeField] Transform cameraTransform;
        [Header("Movement")]
        public float speed;
        void Awake()
        {
            controller = GetComponent<CharacterController>();
            input = GetComponent<Player_Input>();
        }

        void Start()
        {

        }


        void Update()
        {
            bool grounded = controller.isGrounded;
            Movement(input.characterInput);
            
        }

        public void Movement(CharacterInput input)
        {
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;
            camForward.y = 0;
            camRight.y = 0;
            camForward = camForward.normalized;
            camRight = camRight.normalized;
            
            Vector3 move = camRight * input.move.x + camForward * input.move.y;
            controller.Move(move * (speed * Time.deltaTime));

        }
        
        // public void UpdateInput()
    }
}