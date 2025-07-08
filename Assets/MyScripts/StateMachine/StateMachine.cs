using System;
using UnityEngine;
using System.Collections.Generic;

public class StateMachine: MonoBehaviour
{
    private IState currentState;
    private Dictionary<Type, IState> states = new();


    public void Awake()
    {
        var s = GetComponents<IState>();
        foreach (var t in s)
        {
            AddState(t);
        }

        ChangeState<PlayerSpeedControllerORDSTATE>();
    }

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