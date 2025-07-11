using Assets.MyScripts.PlayerController;

using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    [SerializeField] private GameObject player;
    [SerializeField] private float jumpForce;
    Rigidbody2D rb;
    private bool shouldJump = false;


    //public void TRY() { }


    protected override void Start()
    {
        base.Start();
        rb = player.GetComponent<Rigidbody2D>();
        //InputManager.Instance.OnLeftClickPressed += JumpON;
        //InputManager.Instance.OnLeftClickReleased += JumpOff;
    }
    //private void JumpON()
    //{
    //    shouldJump = true;
    //}
    //private void JumpOff()
    //{
    //    shouldJump = false;
    //    StateMachine.ChangeState<PlayerSpeedControllerORDSTATE>();

    //}

    void Update()
    {
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


            //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //rb.AddForce(new Vector2(1, jumpForce), ForceMode2D.Impulse);
            StateMachine.ChangeState<PlayerSpeedControllerORDSTATE>();
        }
    }
}
