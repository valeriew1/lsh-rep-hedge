using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToMenyButtonScript : MonoBehaviour
{

    [SerializeField] Button BackToMenu;
    // Start is called before the first frame update
    void Start()
    {
        BackToMenu.onClick.AddListener(onBackToMenuButton);
    }

    public void onBackToMenuButton() 
    {
        GameManager.Instance.LoadScene("MainMenu");
    }
}
