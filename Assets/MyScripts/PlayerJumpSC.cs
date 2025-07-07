using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSC : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float jumpForce = 5.0f;

    Rigidbody2D rb;
    private bool shouldJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shouldJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (shouldJump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            shouldJump = false;
        }
    }

    



}
