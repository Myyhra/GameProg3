using UnityEngine;
using UnityEngine.Audio;

namespace Week3Scripts
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent (typeof(OnCollisionHandling))]
    public class AudioHandling : MonoBehaviour
    {
        [Header("Audio")]
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClip;
        }

       
        void Update()
        {
        
        }
        public void PlayAudio()
        {
            audioSource.Play();
            Debug.Log("Play Audio");
        }
        
    }
}
