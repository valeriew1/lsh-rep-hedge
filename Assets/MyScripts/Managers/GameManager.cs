using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    // Состояния игры
    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
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
            
            CurrentFoodNum = Convert.ToInt32((CurrentFoodNum - 1)*Time.deltaTime); 
        }


        //CurrentFoodNum--;
    }


    private GameState currentState = GameState.MainMenu;
    
    // События для подписки других скриптов
    public delegate void OnStateChanged(GameState newState);
    public event OnStateChanged onStateChanged;
    
    // Свойство для получения текущего состояния
    public GameState CurrentState 
    { 
        get { return currentState; }
    }
    
    protected override void Awake()
    {
        base.Awake();
    }
    
    // Изменение состояния игры
    public void ChangeState(GameState newState)
    {
        if (currentState == newState)
        {
            return;
        }
        
        currentState = newState;
        
        // Вызываем событие
        onStateChanged?.Invoke(newState);
        
        // Логика для каждого состояния
        switch (newState)
        {
            case GameState.MainMenu:
                Time.timeScale = 1f;
                Debug.Log("Главное меню");
                break;
                
            case GameState.Playing:
                Time.timeScale = 1f;
                Debug.Log("Игра началась");
                break;
                
            case GameState.Paused:
                Time.timeScale = 0f;
                Debug.Log("Игра на паузе");
                break;
                
            case GameState.GameOver:
                Time.timeScale = 0f;
                Debug.Log("Игра окончена");
                break;
        }
    }
    
    // Базовые методы управления игрой
    public void StartGame()
    {
        ChangeState(GameState.Playing);
    }
    
    public void PauseGame()
    {
        if (currentState == GameState.Playing)
            ChangeState(GameState.Paused);
    }
    
    public void ResumeGame()
    {
        if (currentState == GameState.Paused)
            ChangeState(GameState.Playing);
    }
    
    public void GameOver()
    {
        ChangeState(GameState.GameOver);
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ChangeState(GameState.Playing);
    }
}