using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine: MonoBehaviour
//public class StateMachine: Singleton<StateMachine>
{
    private IState currentState;
    private Dictionary<Type, IState> states = new();

    //для синглтона переделала
    //protected override void Awake()
    //{
    //    base.Awake();
    //    var s = GetComponents<IState>();
    //    foreach (var t in s)
    //    {
    //        AddState(t);
    //    }

    //    ChangeState<PlayerSpeedControllerORDSTATE>();
    //}


    public void Awake()
    { 
        var s = GetComponents<IState>();
        foreach (var t in s)
        {
            AddState(t);
        }

        ChangeState<PlayerSpeedControllerORDSTATE>();
    }




    //перенесено из гейм мэнэджера:

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


    //сбор еды по проверке
    //public void FoodCollectBar() { }



    // Добавление состояния в машину состояний
    public void AddState(IState state)
    {
        Type stateType = state.GetType();
        states.TryAdd(stateType, state);
    }
    
    // Смена состояния
    public void ChangeState<T>() where T : IState
    {
        System.Type stateType = typeof(T);
        
        if (!states.ContainsKey(stateType))
        {
            Debug.LogError($"Состояние {stateType} не найдено в StateMachine!");
            return;
        }
        
        // Выходим из текущего состояния
        if (currentState != null)
        {
            currentState.Exit();
        }
        
        // Меняем состояние
        currentState = states[stateType];
        
        // Входим в новое состояние
        currentState.Enter();
        
        Debug.Log($"Состояние изменено на: {stateType.Name}");
    }

    // Обновление текущего состояния
    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }

    public void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.ProcessFixedUpdate();
        }
    }

    // Получить текущее состояние
    public IState GetCurrentState()
    {
        return currentState;
    }
    
    // Проверка текущего состояния
    public bool IsInState<T>() where T : IState
    {
        return currentState != null && currentState.GetType() == typeof(T);
    }
}