using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{

    [SerializeField] Button PauseButton;
    
    void Start()
    {
        InputManager.Instance.OnPausePressed += PauseCanvasAppear;
    }

    public void PauseCanvasAppear()
    {
        Canvas[] allCanvases = Resources.FindObjectsOfTypeAll<Canvas>();
        foreach (Canvas canvas in allCanvases)
        {
            if (canvas.name == "PauseCanvas")
            {
                canvas.gameObject.SetActive(true);
                GameManager.Instance.PauseGame();

            }
            if (canvas.name == "onLevelCanvas") 
            { 
                canvas.gameObject.SetActive(false);
                
            }
        }
    }

}
