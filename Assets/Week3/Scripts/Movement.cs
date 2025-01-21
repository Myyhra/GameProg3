using UnityEngine;

namespace Week3.Scripts
{
    [RequireComponent(typeof(InputHandling))]
    [RequireComponent(typeof(CharacterController))]

    public class Movement : MonoBehaviour
    {
     [Header("Movement")]
     [Tooltip("HorizontalSpeed")]
     [SerializeField] private float moveSpeed;

     [Tooltip("Movement Speed Rate of Change")]
     [SerializeField] private float moveAccel;
     [Tooltip("Decelerate when no input is provided")]
     [SerializeField] private float moveDeccel;
     
     private float currentSpeed;
     private CharacterController charControl;
     private float initialYPosition;
     
     private InputHandling inputHandling;
        void Start()
        {
            inputHandling = GetComponent<InputHandling>();
            charControl = GetComponent<CharacterController>();
        }
        void Update()
        {
            Vector3 inputVector = inputHandling.inputVector;
            Move(inputVector);
        }
        private void Move(Vector3 inputVector)
        {
            if(inputVector == Vector3.zero)
            {
                if (currentSpeed > 0)
                {
                    currentSpeed -= moveDeccel * Time.deltaTime;
                    currentSpeed = Mathf.Max(currentSpeed, 0);
                }
            }

            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, Time.deltaTime * moveAccel);
            }
            
            Vector3 movement = inputVector.normalized * ( currentSpeed * Time.deltaTime);
            charControl.Move(movement);
            transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
        }
    }
}
