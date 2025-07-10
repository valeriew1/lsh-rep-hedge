using Assets.MyScripts.PlayerController;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private StateMachine statemach;

    public static LevelManager Instance { get; private set; }

    protected virtual void Awake()
    {
        Instance = this;


    }




    //еда и ускорение:

    [SerializeField] private TMP_Text textField;
    private int maxfoodcounter = 0;

    [SerializeField] private UnityEngine.UI.Slider sliderbar;
    //[SerializeField] private int MaxFoodNum;
    [SerializeField] private float MaxFoodNum;
    [SerializeField] private float MinFoodNum;
    //private int CurrentFoodNum = 0;
    private float CurrentFoodNum = 0f;



    public void IncreaseScore()
    {
        maxfoodcounter++;
        textField.text = Convert.ToString(maxfoodcounter);

        //if (CurrentFoodNum < MaxFoodNum) { CurrentFoodNum++; Debug.Log(CurrentFoodNum); }
        //CurrentFoodNum++;

    }

    public void IncreaseBar()
    {
        if (CurrentFoodNum < MaxFoodNum)
        {
            CurrentFoodNum++; Debug.Log(CurrentFoodNum); 
        }
    }

    public void CanSLideMore() 
    {
        if (CurrentFoodNum >= MinFoodNum) 
        {
            //SlideBarDown();
            //while (CurrentFoodNum > 0) { statemach.ChangeState<PlayerSpeedUpState>(); }
            statemach.ChangeState<PlayerSpeedUpState>();
            //for (int i = 0; i < MaxFoodNum; i++)
            //{
            //var stateMachine = gameObject.GetComponent<StateMachine>();
            //statemach.ChangeState<PlayerSpeedUpState>();
            //}
        }
    }

    public void SLideBar()
    {
        //CurrentFoodNum = _CurrentFoodNum;
        if (sliderbar)
        {
            sliderbar.value = (float)CurrentFoodNum / MaxFoodNum;

        }


    }

    public void SlideBarDown() 
    {
        //while (CurrentFoodNum > 0)
        //{ 
        //    //CurrentFoodNum = Convert.ToInt32((CurrentFoodNum - 1) * Time.deltaTime); 
        //    CurrentFoodNum = (CurrentFoodNum - 1f) * Time.deltaTime; 

        //}

        CurrentFoodNum -= Time.deltaTime;
        //CurrentFoodNum = (CurrentFoodNum - 1f) * Time.deltaTime;
        SLideBar();
        if (CurrentFoodNum == 0) 
        { 
            statemach.ChangeState<PlayerSpeedControllerORDSTATE>(); 
        }
           
    }

    //public void SlideTimer() 
    //{ 
    //    for (int i = 0; )
    //}



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
