using UnityEngine;
using Week3Scripts;
using UnityEngine.UI;

namespace Week3Scripts
{


    [RequireComponent(typeof(Customizer_F))]
    [RequireComponent(typeof(Customizer_M))]
    public class GenderPick : MonoBehaviour
    {
        [Header("Gender")] public GameObject[] genders;
        public Button genderNext;
        public Button genderPrevious;
        public bool genderToggle;
        Customizer_F cf;
        Customizer_M mf;

        void Awake()
        {
            cf = GetComponent<Customizer_F>();
            mf = GetComponent<Customizer_M>();
        }

        void Start()
        {
            //Gender
            genders[0].SetActive(true);
            genders[1].SetActive(false);
            genderNext.onClick.AddListener(() => { GenderCycle(true); });
            genderPrevious.onClick.AddListener(() => { GenderCycle(false); });
        }

        void GenderCycle(bool next)
        {
            int i = next ? 1 : 0;
            cf.enabled = !next;
            mf.enabled = next;
            genders[0].SetActive(i == 0);
            genders[1].SetActive(i == 1);
            // genderToggle = next;
            // if (genderToggle)
        }

    }
}
