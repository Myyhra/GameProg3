using UnityEngine;
using UnityEngine.InputSystem;
namespace Week9
{
    public struct CharacterInput
    {
        public Vector2 move;
        public bool jump;
        public bool interacting;
    }

    public struct cameraInput
    {
        public Vector2 look;
    }

    public struct mouseInput
    {
        public bool LeftClick;
        public bool RightClick;
    }
    public class Player_Input : MonoBehaviour
    {
        
        [Header("Player Scripts")]
        /*[SerializeField]*/ Player_Movement _playerMovement;
        [SerializeField] Player_CameraMovement _playerCameraMovement;
        /*[SerializeField]*/ Player_Camera _playerCamera;
        
        //ActionField
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _interactAction;
        private InputAction _jumpAction;
        private InputAction _LeftMouseAction;
        private InputAction _RightMouseAction;
        
        
        public CharacterInput characterInput { get; private set; }
        public cameraInput cameraInput { get; private set; }
        public mouseInput mouseInput { get; private set; }

        public bool isHolding { get; private set; }
        
        
        //Interfaces
        private IPlayerMoveable _IPlayerMoveable;
        private IAttackable _IAttackable;
        private IMouseMovable _IMouseMovable; // For Player_CameraMovement
        
        void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _moveAction = InputSystem.actions.FindAction("Move");
            _lookAction = InputSystem.actions.FindAction("Look");
            _interactAction = InputSystem.actions.FindAction("Interact");
            _jumpAction = InputSystem.actions.FindAction("Jump");
            _LeftMouseAction = InputSystem.actions.FindAction("Attack");
            _RightMouseAction = InputSystem.actions.FindAction("Alternate_Attack");
            
            
            _IPlayerMoveable = GetComponent<IPlayerMoveable>();
            _IAttackable = GetComponent<IAttackable>();
            _IMouseMovable = _playerCameraMovement.GetComponent<IMouseMovable>();

            /*if (_IAttackable is Player_GravityGun_Attack gravityGun)
            {
                gravityGun.SetCameraDirection(_playerCameraMovement);
            }*/


        }
        void Start()
        {

        }
        void Update()
        {
            characterInput = new CharacterInput()
            {
                move = _moveAction.ReadValue<Vector2>(),
                interacting = _interactAction.IsPressed(),
                jump = _jumpAction.WasPressedThisFrame()
                
            };
            cameraInput = new cameraInput()
            {
                look = _lookAction.ReadValue<Vector2>(),
            };
            
            mouseInput = new mouseInput()
            {
                LeftClick = _LeftMouseAction.WasPressedThisFrame(),
                RightClick = _RightMouseAction.WasPressedThisFrame()
                
            };
            
            
            //Inputting to the interface
            // _IPlayerMoveable.Backwards(-characterInput.move.y); //Apparently with a float parameter on the interface, you can just do this xd
            _IPlayerMoveable.Move(characterInput.move);
            _IPlayerMoveable.Jump(characterInput.jump);
            _IMouseMovable.UpdateCamera(cameraInput.look); //Camera Rotation
            MouseClicks();
            
            


            //Also would be nice to use interfaces for inputs instead of this direct
            

        }

        void MouseClicks()
        {
            if (mouseInput.LeftClick)
            {
                _IAttackable.Attack();
            }
            if (mouseInput.RightClick)
            {
                _IAttackable.AlternateAttack();
            }
        }
        
        
        
    }
}