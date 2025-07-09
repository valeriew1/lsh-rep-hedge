using Assets.MyScripts.Managers;
using Assets.MyScripts.PlayerController;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodCollectTrigger : MonoBehaviour
{

    //private int MaxFoodNum;
    //private int CurrentFoodNum = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        var stateMachine = collision.gameObject.GetComponent<StateMachine>();
        
        if (stateMachine.GetCurrentState() is not PlayerSpeedUpState)
        {
            //GameManager.Instance.IncreaseBar();
            //LevelManager.Instance.IncreaseBar();
        }


        //GameManager.Instance.IncreaseScore();
        //if (StateMachine.ge.GetCurrentState = PlayerSpeedControllerORDSTATE)
        //if (StateMachine.Instance.GetCurrentState() == StateMachine.Instance.PlayerSpeedUpState);
        //GameManager.Instance.IncreaseBar();

        //while (CurrentFoodNum < MaxFoodNum)
        //{
        //    GameManager.Instance.IncreaseBar();
        //}

    }

    //[SerializeField] private GameObject foodOBJ;
    //[SerializeField] private GameObject player;


    //Rigidbody2D rbFood;
    //Rigidbody2D rbPlayer;



    // Start is called before the first frame update
    void Start()
    {
    //    rbFood = foodOBJ.GetComponent<Rigidbody2D>();
    //    rbPlayer = player.GetComponent<Rigidbody2D>();
    //    textField = textField.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
