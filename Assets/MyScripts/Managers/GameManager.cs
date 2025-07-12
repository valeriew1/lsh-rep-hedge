using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    private GameState currentState = GameState.MainMenu;
    
    public delegate void OnStateChanged(GameState newState);
    public event OnStateChanged onStateChanged;
    
    
    public GameState CurrentState 
    { 
        get { return currentState; }
    }
    
    protected override void Awake()
    {
        base.Awake();
    }
    
    public void ChangeState(GameState newState)
    {
        if (currentState == newState)
        {
            return;
        }
        
        currentState = newState;
        
        onStateChanged?.Invoke(newState);
        
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