using UnityEngine;

namespace Week3.Scripts
{
    public class NewMonoBehaviourScript : MonoBehaviour
    {[Header("Movement")]
    [Tooltip("HorizontalSpeed")]
    [SerializeField] private float moveSpeed;

    [Tooltip("Movement Speed Rate of Change")]
    [SerializeField] private float moveAccel;
    [Tooltip("Decelerate when no input is provided")]
    [SerializeField] private float moveDeccel;

    [Header("Controls")]
    [Tooltip("Use keys to move")]
    [SerializeField] private KeyCode forward;
    [SerializeField] private KeyCode backward;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;

    [Header("Audio")]
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    [Header("Effects")]
    [SerializeField] private ParticleSystem particleSys;

    [Header("Collision")]
    [SerializeField] LayerMask wall;

    private Vector3 inputVector;
    private float currentSpeed;
    private CharacterController charControl;
    private float initialYPosition;
    
    private void Awake()
    {
        charControl = GetComponent<CharacterController>();
        initialYPosition = transform.position.y;
    }
    void Start()
    {

    }

    void Update()
    {
        HandlesInput();
        Move(inputVector);
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

        Vector3 movement = inputVector.normalized * currentSpeed * Time.deltaTime;
        charControl.Move(movement);
        transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
    }

    private void PlayAudio()
    {
        audioSource.Play();
    }

    private void PlayParticleEffect()
    {
        particleSys.Play();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((wall.value & (1<< hit.gameObject.layer))>0)
        {
            PlayAudio();
            PlayParticleEffect();
        }
    }
    }
}
