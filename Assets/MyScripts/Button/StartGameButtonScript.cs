using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButtonScript : MonoBehaviour
{
    [SerializeField] Button StartGameButton;
    //[SerializeField] private int ;

    void Start()
    {
        StartGameButton.onClick.AddListener(onStartGameButtonScript);
    }

    public void onStartGameButtonScript()
    {
        GameManager.Instance.LoadScene("Level");
        GameManager.Instance.StartGame();
    }

}
