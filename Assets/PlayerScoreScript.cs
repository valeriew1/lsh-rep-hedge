using Assets.MyScripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerScoreScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = LiderBoard.GetLastEntry().score.ToString();

    }

}
