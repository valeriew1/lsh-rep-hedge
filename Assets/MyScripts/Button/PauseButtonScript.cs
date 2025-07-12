using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{

    [SerializeField] Button PauseButton;
    //GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        //PauseButton.onClick.AddListener(PauseCanvasAppear);
        //gameManager.PauseGame();
        InputManager.Instance.OnPausePressed += PauseCanvasAppear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PauseCanvasAppear()
    {
        //gameManager.PauseGame();
        //GameManager.ChangeState(PauseGame());
        //GameManager.ChangeState(GameManager.Instance.PauseGame());
        //GameManager.Instance.PauseGame();
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

   
    //public void OnMouseOver()
    //{
           
    //}

}
