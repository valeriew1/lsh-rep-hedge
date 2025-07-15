using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EducationOpenButtonScript : MonoBehaviour
{
    [SerializeField] Button educationSceneOpener;
    void Start()
    {
        educationSceneOpener.onClick.AddListener(OnEducationButton);
    }

    public void OnEducationButton() 
    {
        GameManager.Instance.LoadScene("Education"); 
    }

}
