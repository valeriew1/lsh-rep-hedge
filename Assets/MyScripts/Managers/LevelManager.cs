using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.MyScripts.Managers
{
    public class LevelManager<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;



            }
        }



        [SerializeField] private TMP_Text textField;
        private int maxfoodcounter = 0;

        [SerializeField] private Slider slider;
        [SerializeField] private int MaxFoodNum;
        private int CurrentFoodNum = 0;


        public void IncreaseScore()
        {
            maxfoodcounter++;
            //while (CurrentFoodNum < MaxFoodNum) { CurrentFoodNum++; Debug.Log(CurrentFoodNum); }

            //CurrentFoodNum++;

            textField.text = Convert.ToString(maxfoodcounter);
        }

        public void IncreaseBar() { CurrentFoodNum++; Debug.Log(CurrentFoodNum); }

        //public void SLideBar(int _CurrentFoodNum) 
        public void SLideBar()
        {
            //CurrentFoodNum = _CurrentFoodNum;
            if (slider)
            {
                slider.value = (float)CurrentFoodNum / MaxFoodNum;
            }


        }


        //PlayerJumpState.Instance.TRY();

        public void SlideBarDown()
        {
            while (slider.value > 0)
            {

                CurrentFoodNum = Convert.ToInt32((CurrentFoodNum - 1) * Time.deltaTime);
            }


            //CurrentFoodNum--;
        }


    }
}
