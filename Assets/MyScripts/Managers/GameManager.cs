using UnityEngine;
using UnityEngine.SceneManagement;

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