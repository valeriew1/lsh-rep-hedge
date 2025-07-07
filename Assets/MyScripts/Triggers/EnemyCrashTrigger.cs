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
        //collision = enemy.GetComponent<Collider2D>();
        collision = player.GetComponent<Collider2D>();

        //if (collision.CompareTag("Player"))
        //{
        player.transform.position = worldPosSTART;
        //}

    }


    //GameObject player;
    //public GameObject playerSTARTLOC;
    //private Vector2 worldPosSTART;
    //private Rigidbody2D rb;
    //void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    //ballSTARTLOC = GameObject.Find("PlayerStartPoint");
    //    rb = player.GetComponent<Rigidbody2D>();
    //    Transform PlayerSTARTLOC_transform = playerSTARTLOC.transform;
    //    worldPosSTART = PlayerSTARTLOC_transform.position;
    //}
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (player != null && other.CompareTag("Player"))
    //    {
    //        player.transform.position = worldPosSTART;
    //        rb.gravityScale = 0f;
    //        rb.mass = 0f;

    //        //rb.linearVelocity = Vector2.zero;

    //    }
    //}
}
