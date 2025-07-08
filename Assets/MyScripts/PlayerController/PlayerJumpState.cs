using Assets.MyScripts.PlayerController;

using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    [SerializeField] private GameObject player;
    [SerializeField] private float jumpForce = 5.0f;
    Rigidbody2D rb;
    private bool shouldJump = false;

    protected override void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();

        base.Start();
    }

    void Update()
    {
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        shouldJump = true;
    //    }
    }

    private void FixedUpdate()
    {
        //if (shouldJump)
        //{
        //    rb.AddForce(transform.right * jumpForce, ForceMode2D.Impulse);
        //    shouldJump = false;
        //}
    }

    public override void Enter()
    {
        shouldJump = true;
    }

    public override void Execute()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    shouldJump = true;
        //}
    }

    public override void Exit()
    {
        shouldJump = false;
    }

    public override void ProcessFixedUpdate()
    {
        if (shouldJump)
        {
            rb.AddForce(transform.right * jumpForce, ForceMode2D.Impulse);
            
            StateMachine.ChangeState<PlayerSpeedControllerORDSTATE>();
        }
    }
}
