using Assets.MyScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrashTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;


    Rigidbody2D rbPLayer;
    Rigidbody2D rbEnemy;

    private Vector2 worldPosSTART;

    private void Start()
    {
        rbPLayer = player.GetComponent<Rigidbody2D>();
        rbEnemy = enemy.GetComponent<Rigidbody2D>();

        Transform PlayerSTARTLOC_transform = player.transform;
        worldPosSTART = PlayerSTARTLOC_transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            LiderBoard.AddScore("", LevelManager.Instance.GetMaxFoodCounter());

            GameManager.Instance.LoadScene("DeathScreen");

            //    player.transform.position = worldPosSTART; 
            //    rbPLayer.velocity = Vector2.zero;
            //GameManager.Instance.RestartLevel();
        }

    }
}
