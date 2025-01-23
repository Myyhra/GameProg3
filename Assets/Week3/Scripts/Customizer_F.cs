using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace Week3Scripts
{
    
    [System.Serializable]
    public class Parts
    {
        public string name = "";
        public GameObject[] PartType;
        public Button nextPart;
        public Button previousPart;
        public int currentIndex = 0;
    }
    public class Customizer_F : MonoBehaviour
    {
        public List<Parts> bodyParts = new List<Parts>();
        
        void OnEnable()
        {
            
            //BodyParts
            foreach (Parts part in bodyParts)
            {
                part.currentIndex = 0;

                foreach (GameObject g in part.PartType)
                {
                    g.SetActive(false);
                }
                part.PartType[part.currentIndex].SetActive(true);
                part.nextPart.onClick.RemoveAllListeners();
                part.previousPart.onClick.RemoveAllListeners();
                part.nextPart.onClick.AddListener(() => { PartCycle(part,true);});
                part.previousPart.onClick.AddListener(() => { PartCycle(part,false); });
            }
        }

       

        void PartCycle(Parts part, bool next)
        {
            part.PartType[part.currentIndex].SetActive(false);
            part.currentIndex += next ? 1 : -1;
            part.currentIndex = (part.currentIndex + part.PartType.Length) % part.PartType.Length;
            part.PartType[part.currentIndex].SetActive(true);
        }

        void Update()
        {

        }
    }
}
