using Assets.MyScripts.PlayerController;

using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    [SerializeField] private GameObject player;
    [SerializeField] private float ORDjumpForce;
    private float jumpForce = 20f;
    Rigidbody2D rb;

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

    }
    
    public void ScreenPieaces()
    {
        SCRwidth = Screen.width;
        SCRleft = SCRwidth / 3;
        SCRright = (SCRwidth / 3) * 2;

    }


    void Update()
    {
    }

    private void FixedUpdate()
    {
        
    }

    public override void Enter()
    {

    }


    public override void Execute()
    {
        curentMousePos = Input.mousePosition.x;
    }

    public override void Exit()
    {
    }

    public override void ProcessFixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        Vector2 normal = PlayerSpeedControllerORDSTATE.lastGroundNormal.normalized;

        Vector2 tangent = new Vector2(-normal.y, normal.x);

        float tangentSpeed = Vector2.Dot(velocity, tangent);

        float g = Mathf.Abs(Physics2D.gravity.y * rb.gravityScale);
        float desiredHeight = 3f;
        float v_jump = Mathf.Sqrt(2 * g * desiredHeight);

        Vector2 newVelocity = tangent * tangentSpeed + normal * v_jump;
        Debug.DrawLine(player.transform.position, player.transform.position + (Vector3)newVelocity.normalized * 10, Color.blue, 10);

        rb.velocity = newVelocity;

        StateMachine.ChangeState<PlayerSpeedControllerORDSTATE>();

    }
}
