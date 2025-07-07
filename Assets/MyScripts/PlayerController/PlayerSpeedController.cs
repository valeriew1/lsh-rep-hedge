using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float velocity;

    Rigidbody2D rb;
    private bool shouldSlide = false;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        InputManager.Instance.OnRightClickPressed += SlideInput;
    }

    void Update()
    {
        Debug.Log(rb.velocity.magnitude);
        //rb.sharedMaterial.friction
    }

    private void FixedUpdate()
    {
        if (shouldSlide)
        {
            rb.AddForce(new Vector2(jumpForce, 0), ForceMode2D.Impulse);
            shouldSlide = false;
        }
    }


    private void SlideInput()
    {
        shouldSlide = true;
    }

}
