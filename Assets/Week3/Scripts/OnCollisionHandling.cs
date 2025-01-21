using UnityEngine;

namespace Week3Scripts
{
    [RequireComponent(typeof(AudioHandling))]
    [RequireComponent(typeof(Particle))]
    public class OnCollisionHandling : MonoBehaviour
    {
        [Header("Collision")]
        [SerializeField] LayerMask wall;
        private AudioHandling audio;
        private Particle explosionParticles;
        private void Awake()
        {
            audio = GetComponent<AudioHandling>();
            explosionParticles = GetComponent<Particle>();
        }
        void Start()
        {
        
        }

        void Update()
        {
        
        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if ((wall.value & (1 << hit.gameObject.layer)) > 0)
            {
                audio.PlayAudio();
                explosionParticles.PlayParticleEffect();

            }
        }
    }
}
