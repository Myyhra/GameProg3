using UnityEngine;

namespace Week9
{


    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        public GameObject Pickup;
        public GameObject Drop;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        void Start()
        {

        }


        void Update()
        {
            
        }
    }
}