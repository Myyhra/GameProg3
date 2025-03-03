using UnityEngine;

namespace Week9
{
    
    [RequireComponent(typeof(Player_Input))]
    [RequireComponent(typeof(CharacterController))]
    public class Player_Movement : MonoBehaviour, IPlayerMoveable
    {
        private CharacterController controller;
        // private Player_Input input;
        [SerializeField] Transform cameraTransform;
        [Header("Movement")]
        public float speed;
        public float jumpForce;

        private Vector3 velocity;
        private bool isGrounded;
        private Vector2 currentInputDirection;
        // private bool jumpRequested;
        void Awake()
        {
            controller = GetComponent<CharacterController>();
            // input = GetComponent<Player_Input>();
        }

        void Start()
        {
            
        }


        void Update()
        {
            
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;
            camForward.y = 0;
            camRight.y = 0;
            camForward = camForward.normalized;
            camRight = camRight.normalized;
            
            Vector3 move = camRight * currentInputDirection.x + camForward * currentInputDirection.y;
            Vector3 horizontalVelocity = move * speed;
            
            
            
            Gravity();
            
            Vector3 totalVelocity = horizontalVelocity + new Vector3(0, velocity.y, 0);
            controller.Move(totalVelocity * Time.deltaTime);
          
           
            isGrounded = controller.isGrounded;
        }
        
        
        // public void UpdateInput()
        //So apparently interface methods are being called every frame
        private void CameraRightMovement()
        {
            
        }
        public void Move(Vector2 direction)
        {
            
            currentInputDirection = direction;
            
            
            //Debug Logs
            if (direction.y > 0) Debug.Log("Player movement script is receiving interface calls & Going Forward");
            if (direction.y < 0) Debug.Log("Player movement script is receiving interface calls & Going Back");
            if (direction.x > 0) Debug.Log("Player movement script is receiving interface calls & Going Right");
            if (direction.x < 0) Debug.Log("Player movement script is receiving interface calls & Going Left");
        }
        
        //Might put in a separate script
        public void Jump(bool jump)
        {
            // jumpRequested = jump;                //Should try making jump buffering & Coyote Jump in the future
            //Jump Handling
            if (isGrounded && jump)
            {
                velocity.y = jumpForce;
                // jumpRequested = false;
            }
        }
        //Might put in a separate script
        private void Gravity()
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0;

            }
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }


        /*public Vector3 Movement(CharacterInput input)
       {
           Vector3 camForward = cameraTransform.forward;
           Vector3 camRight = cameraTransform.right;
           camForward.y = 0;
           camRight.y = 0;
           camForward = camForward.normalized;
           camRight = camRight.normalized;

           Vector3 move = camRight * input.move.x + camForward * input.move.y;
           return move * (speed * Time.deltaTime);
       }*/

        /*public void Jump(bool jumpInput)
        {

            if (jumpInput && controller.isGrounded)
            {
                velocity.y = jumpForce;
            }

        }*/
    }
    
}