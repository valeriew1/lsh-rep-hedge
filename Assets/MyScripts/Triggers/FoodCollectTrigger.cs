using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodCollectTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;

    //private int MaxFoodNum;
    //private int CurrentFoodNum = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

            LevelManager.Instance.IncreaseScore();
            LevelManager.Instance.IncreaseBar();
        }

    }


}
