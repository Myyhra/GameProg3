using UnityEngine;
using Week3Scripts;

namespace Week3Scripts
{
    [RequireComponent(typeof(OnCollisionHandling))]
    public class Particle : MonoBehaviour
    {
        [SerializeField] ParticleSystem particleSys;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //Add if the explosion is missing, spawn it
        }
        public void PlayParticleEffect()
        {
            particleSys.Play();
            Debug.Log("Play explosion");
           
        }
    }
}
