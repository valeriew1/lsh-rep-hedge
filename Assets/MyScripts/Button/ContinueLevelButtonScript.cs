using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueLevelButtonScript : MonoBehaviour
{

    [SerializeField] Button ContinueLevelButton;
    void Start()
    {
        ContinueLevelButton.onClick.AddListener(ContinueLevel);
    }

    public void ContinueLevel() 
    {
        Canvas[] allCanvases = Resources.FindObjectsOfTypeAll<Canvas>();
        foreach (Canvas canvas in allCanvases)
        {
            if (canvas.name == "onLevelCanvas")
            { 
                canvas.gameObject.SetActive(true);
                GameManager.Instance.ResumeGame();
            }
            if (canvas.name == "PauseCanvas")
            {
                canvas.gameObject.SetActive(false);
            }

        }
    }

}
