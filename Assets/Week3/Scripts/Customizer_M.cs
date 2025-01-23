using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;
namespace Week3Scripts
{
    [System.Serializable]
    public class MParts
    {
        public string name = "";
        public GameObject[] PartType;
        public Button nextPart;
        public Button previousPart;
        public int currentIndex = 0;
    }
    public class Customizer_M : MonoBehaviour
    {

        public List<MParts> bodyParts = new List<MParts>();
        // public List<Parts> parts = new List<Parts>();
        void OnEnable()
        {
            
            //BodyParts
            foreach (MParts part in bodyParts)
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
        
        void PartCycle(MParts part, bool next)
        {
            part.PartType[part.currentIndex].SetActive(false);
            part.currentIndex += next ? 1 : -1;
            part.currentIndex = (part.currentIndex + part.PartType.Length) % part.PartType.Length;
            part.PartType[part.currentIndex].SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}