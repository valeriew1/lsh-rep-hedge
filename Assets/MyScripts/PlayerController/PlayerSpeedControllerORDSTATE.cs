using Assets.MyScripts.PlayerController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//public class PlayerSpeedController : MonoBehaviour, IState

public class PlayerSpeedControllerORDSTATE : PlayerStateBase
{
    [SerializeField] private GameObject player;
    [SerializeField] private float ORDSpeed;
    private float currentSpeed;
    [SerializeField] private GameObject ground;
    Rigidbody2D rbGROUND;
    Rigidbody2D rb;

    private bool onEarth = false;

    private float SCRwidth;
    private float SCRleft;
    private float SCRright;
    private float curentMousePos;



    protected override void Start()
    {

        base.Start();
        rb = player.GetComponent<Rigidbody2D>();
        rbGROUND = ground.GetComponent<Rigidbody2D>();

        ScreenPieaces();

        GameManager.Instance.StartGame();
    }
    private void ScreenPieaces() 
    {
        SCRwidth = Screen.width;
        SCRleft = SCRwidth / 3;
        SCRright = (SCRwidth / 3)*2;

    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        
    }

    public override void Enter() { }

    public override void Execute()
    {

        curentMousePos = Input.mousePosition.x;

        if (GameManager.Instance.CurrentState == GameManager.GameState.Playing)
        {

            if (Input.GetMouseButtonDown(0))
            {
                //прыжок, не трожь
                if (onEarth)
                {
                    StateMachine.ChangeState<PlayerJumpState>();
                    onEarth = false;
                    return;


                }
            }
            //ускорение, не трожь!
            else if (Input.GetMouseButtonDown(1))
            {

                LevelManager.Instance.CanSLideMore();
               

            }
            else
            {
                LevelManager.Instance.SLideBar();


                if (onEarth)
                {
                    if (curentMousePos < SCRleft) { currentSpeed = ORDSpeed - 3; }
                    else if (curentMousePos > SCRright) { currentSpeed = ORDSpeed + 3; }
                    else { currentSpeed = ORDSpeed; }
                }


            }
        }
    }

    //public void HUETA() { }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (ground = other.gameObject)
        {
            lastGroundNormal = other.contacts[0].normal;
            onEarth = true; 
        }
    }

    public static Vector2 lastGroundNormal = Vector2.up;

    private void OnCollisionExit2D(Collision2D other)
    {
        if (ground = other.gameObject)
        { onEarth = false; }

    } //регулирует второй прыжок - при этом войде прыжок только один



    public override void Exit() { }

    public override void ProcessFixedUpdate()
    {
        //if (ordslide)
        //{
        if (onEarth) 
        {
            //rb.velocity = new Vector2(rb.velocity.normalized.x * currentSpeed, rb.velocity.y); 
            rb.velocity = rb.velocity.normalized * currentSpeed;
        }
        

        //    //rb.velocity = rb.velocity.normalized * currentSpeed;
        //    //Input.mousePosition;
        //    //Screen.width;

        //}
        //if (ordslide == false) { rb.velocity = new Vector2(0, 0); }
        ////LevelManager.Instance.SLideBar();
    }



}