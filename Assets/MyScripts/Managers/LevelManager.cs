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
    
    [SerializeField] private TMP_Text textField;
    private int maxfoodcounter = 0;

    [SerializeField] private UnityEngine.UI.Slider sliderbar;
    [SerializeField] private float MaxFoodNum;
    [SerializeField] private float MinFoodNum;
    private float CurrentFoodNum = 0f;

    public void IncreaseScore()
    {
        maxfoodcounter++;
        textField.text = Convert.ToString(maxfoodcounter);

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
            statemach.ChangeState<PlayerSpeedUpState>();
            
        }
    }

    public void SLideBar()
    {
        if (sliderbar)
        {
            sliderbar.value = (float)CurrentFoodNum / MaxFoodNum;
        }
    }

    public void SlideBarDown() 
    {
        CurrentFoodNum -= 5*Time.deltaTime;
        SLideBar();
        if (CurrentFoodNum == 0) 
        { 
            statemach.ChangeState<PlayerSpeedControllerORDSTATE>(); 
        }
           
    }

    public void ORDSLideBarDown()
    {
        CurrentFoodNum -= 0.3f* Time.deltaTime;
        SLideBar();
    }
    
    void Start()
    {
    }

}
