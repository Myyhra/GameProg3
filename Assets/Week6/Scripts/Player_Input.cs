using UnityEngine;
using UnityEngine.InputSystem;
namespace Week6
{
    public struct CharacterInput
    {
        public Vector2 move;
        public bool interacting;
    }

    public struct cameraInput
    {
        public Vector2 look;
    }
    public class Player_Input : MonoBehaviour
    {
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _interactAction;
        
        [Header("Player Scripts")]
        [SerializeField] Player_Movement playerMovement;
        [SerializeField] Player_CameraMovement playerCameraMovement;
        [SerializeField] Player_Camera playerCamera;
        
        
        public CharacterInput characterInput { get; private set; }
        public cameraInput cameraInput { get; private set; }

        public bool isHolding { get; private set; }
        void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _moveAction = InputSystem.actions.FindAction("Move");
            _lookAction = InputSystem.actions.FindAction("Look");
            _interactAction = InputSystem.actions.FindAction("Interact");
            
        }

        void Start()
        {

        }


        void Update()
        {
            characterInput = new CharacterInput()
            {
                move = _moveAction.ReadValue<Vector2>(),
                interacting = _interactAction.IsPressed()
            };
            playerMovement.Movement(characterInput);

            cameraInput = new cameraInput()
            {
                look = _lookAction.ReadValue<Vector2>(),
            };
            playerCamera.Interact(characterInput.interacting);
            
            
        }
    }
}