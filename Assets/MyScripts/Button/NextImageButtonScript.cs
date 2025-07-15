using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextImageButtonScript : MonoBehaviour
{
    [SerializeField] Button nextImageButton;
    [SerializeField] GameObject[] images;
    [SerializeField] private int MaxIndex;
    private int Index = 0;


    // Start is called before the first frame update
    void Start()
    {
        nextImageButton.onClick.AddListener(OnNextImageButton);
    }

    public void OnNextImageButton() 
    {
        if (Index + 1 <= MaxIndex)
        {
            images[Index].SetActive(false);
            images[Index + 1].SetActive(true);
            Index++;
        }
    }

}
