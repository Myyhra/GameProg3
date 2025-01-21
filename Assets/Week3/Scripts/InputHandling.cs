using UnityEngine;

namespace Week3Scripts
{
    [RequireComponent(typeof(Movement))]
    public class InputHandling : MonoBehaviour
    {
     [Header("Controls")] [Tooltip("Use keys to move")] [SerializeField]
     private KeyCode forward;
     [SerializeField] private KeyCode backward;
     [SerializeField] private KeyCode left;
     [SerializeField] private KeyCode right;
     public Vector3 inputVector { get; private set; }
     private CharacterController controller;
     
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            HandlesInput();
        }
        private void HandlesInput()
        {
            float xInput = 0;
            float zInput = 0;

            if (Input.GetKey(forward))
            {
                zInput++;
            }

            if (Input.GetKey(backward))
            {
                zInput--;
            }

            if (Input.GetKey(left))
            {
                xInput--;
            }
            if (Input.GetKey(right))
            {
                xInput++;
            }

            inputVector = new Vector3(xInput, 0, zInput);
        }
    }
}
