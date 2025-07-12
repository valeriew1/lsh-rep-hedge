using Assets.MyScripts.PlayerController;

using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    [SerializeField] private GameObject player;
    [SerializeField] private float ORDjumpForce;
    //[SerializeField] private float ORDSpeed;
    //private float currentSpeed;
    private float jumpForce = 20f;
    Rigidbody2D rb;
    //private bool shouldJump = false;


    //public void TRY() { }

    Vector2 jumpDirection;

    private float SCRwidth;
    private float SCRleft;
    private float SCRright;
    private float curentMousePos;

    


    protected override void Start()
    {
        base.Start();
        rb = player.GetComponent<Rigidbody2D>();
        ScreenPieaces();

        //InputManager.Instance.OnLeftClickPressed += JumpON;
        //InputManager.Instance.OnLeftClickReleased += JumpOff;
    }
    
    public void ScreenPieaces()
    {
        SCRwidth = Screen.width;
        SCRleft = SCRwidth / 3;
        SCRright = (SCRwidth / 3) * 2;

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
        //shouldJump = true;
    }


    public override void Execute()
    {
        curentMousePos = Input.mousePosition.x;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    shouldJump = true;
        //}


        if (curentMousePos < SCRleft) { jumpForce = ORDjumpForce - 3; }
        else if (curentMousePos > SCRright) { jumpForce = ORDjumpForce + 3; }
        else { jumpForce = ORDjumpForce; }
        //jumpForce = ORDjumpForce;
    }

    public override void Exit()
    {
        //shouldJump = false;
    }

    public override void ProcessFixedUpdate()
    {

        //float maxJumpSpeed = 10f; // Максимальная скорость при прыжке
        //if (rb.velocity.y > maxJumpSpeed)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, maxJumpSpeed);
        //}


        //if (shouldJump)
        //{

        //if () 
        //{ } 
        //else if () { } 
        //else { }

        //rb.velocity = rb.velocity.normalized * currentSpeed;
        //rb.velocity = new Vector2(0,0);

        //jumpDirection = new Vector2(rb.velocity.normalized.x, 1f).normalized;
        //rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
        //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        rb.AddForce(transform.right * jumpForce, ForceMode2D.Impulse);


        //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        //rb.AddForce(new Vector2(0, ORDjumpForce), ForceMode2D.Impulse);
        //rb.AddForce(new Vector2(1, jumpForce), ForceMode2D.Impulse);
        StateMachine.ChangeState<PlayerSpeedControllerORDSTATE>();
        //}
    }
}
