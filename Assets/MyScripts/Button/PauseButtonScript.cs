using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{

    [SerializeField] Button PauseButton;

    // Start is called before the first frame update
    void Start()
    {
        PauseButton.onClick.AddListener(PauseCanvasAppear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PauseCanvasAppear()
    {
        Canvas[] allCanvases = Resources.FindObjectsOfTypeAll<Canvas>();
        foreach (Canvas canvas in allCanvases)
        {
            if (canvas.name == "PauseCanvas")
            {
                canvas.gameObject.SetActive(true);

            }
            if (canvas.name == "onLevelCanvas") 
            { 
                canvas.gameObject.SetActive(false);
                
            }
        }
    }


    public void OnMouseOver()
    {
           
    }

}
