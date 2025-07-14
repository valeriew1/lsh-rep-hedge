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


    public int GetMaxFoodCounter() 
    {
        return maxfoodcounter;
    }

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

    public void SLideBar()
    {
        if (sliderbar)
        {
            sliderbar.value = (float)CurrentFoodNum / MaxFoodNum;
        }
    }

    public void SlideBarDown() 
    {
        if (CurrentFoodNum > 0)
        {
            CurrentFoodNum -= 5 * Time.deltaTime;
            SLideBar();
        }
           
    }

    public void ORDSLideBarDown()
    {
        if (CurrentFoodNum > 0) 
        {
            CurrentFoodNum -= 0.3f * Time.deltaTime;
            SLideBar();
        }
        
    }

    public bool ZeroCheking() 
    {
        return CurrentFoodNum <= 0;
        
    }
    public bool CanSLideMore()
    {
        return CurrentFoodNum >= MinFoodNum;
        
        
    }

}
