using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartLevelButtonScript : MonoBehaviour
{
    [SerializeField] Button RestartLevelButton;
    
    void Start()
    {
        RestartLevelButton.onClick.AddListener(RestartLevel);
    }

    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }

}
