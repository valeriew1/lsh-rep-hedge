using Assets.MyScripts.PlayerController;
using UnityEngine;

//public class PlayerSpeedController : MonoBehaviour, IState

public class PlayerSpeedControllerORDSTATE : PlayerStateBase
{
    [SerializeField] private GameObject player;
    [SerializeField] private float currentSpeed = 3f;
    Rigidbody2D rb;
    private bool ordslide = true;

    //private bool shouldMoreSlide = false;

    //[SerializeField] private float impForce = 5.0f;
    //[SerializeField] private float velocity;
    //private StateMachine StateMachine;
    //private bool shouldMoreSlide = false;


    protected override void Start()
    {
        base.Start();
        rb = player.GetComponent<Rigidbody2D>();
        //StateMachine = GetComponent<StateMachine>();
        //InputManager.Instance.OnRightClickPressed += SlideInput;
    }

    void Update()
    {
        //Debug.Log(rb.velocity.magnitude);
        //rb.sharedMaterial.friction
    }

    private void FixedUpdate()
    {
        //if (ordslide)
        //{
        //    //rb.velocity = Vector3.zero;
        //    //rb.velocity = new Vector2(5, -5);
        //    //rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        //    rb.velocity = rb.velocity.normalized * curentSpeed;
        //}

        //if (shouldMoreSlide)
        //{
        //    rb.AddForce(new Vector2(impForce, 0), ForceMode2D.Impulse);
        //    shouldMoreSlide = false;
        //    //ordslide = true;
        //}
    }

    public override void Enter() { }

    public override void Execute()
    {
        Debug.Log(rb.velocity.magnitude);
        if (Input.GetMouseButtonDown(0))
        //if (InputManager.Instance.OnRightClickPressed)
        {
            StateMachine.ChangeState<PlayerJumpState>();
        }

        if (Input.GetMouseButtonDown(1))
        {
            StateMachine.ChangeState<PlayerSpeedUpState>();
        }
    }

    public override void Exit() { }

    public override void ProcessFixedUpdate()
    {
        //if (ordslide)
        //{
        rb.velocity = rb.velocity.normalized * currentSpeed;
    }
}