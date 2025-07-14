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
    private bool isSliding = false;

    private float SCRwidth;
    private float SCRleft;
    private float SCRright;
    private float curentMousePos;

    private double impForce = 0;
    private double N;
    [SerializeField] private double X2N;
    [SerializeField] private double t;

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
        //Debug.Log(StateMachine.ChangeState);

        if (GameManager.Instance.CurrentState == GameManager.GameState.Playing)
        {
            LevelManager.Instance.ORDSLideBarDown();
            LevelManager.Instance.SLideBar();

            if (onEarth && !isSliding)
            {
                if (curentMousePos < SCRleft) { currentSpeed = ORDSpeed - 3; }
                else if (curentMousePos > SCRright) { currentSpeed = ORDSpeed + 3; }
                else { currentSpeed = ORDSpeed; }
            }

            if (isSliding)
            {
                LevelManager.Instance.SlideBarDown();
                if (LevelManager.Instance.ZeroCheking()) { isSliding = false; }
            }
            //    if (rb.velocity.magnitude < X2N)
            //    {
            //        rb.AddForce(new Vector2((float)impForce, 0), ForceMode2D.Force);
            //    }

            //    raschet();
            //}


            Debug.Log(Input.GetMouseButtonDown(0));
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("jump");
                //прыжок, не трожь
                if (onEarth)
                {
                    StateMachine.ChangeState<PlayerJumpState>();
                    onEarth = false;
                    return;
                }
            }
            
            //ускорение, не трожь!
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("slide");
                if (LevelManager.Instance.CanSLideMore())
                {
                    isSliding = true;
                }
                //if ()
                //LevelManager.Instance.CanSLideMore();
               
            } 

            if (Input.GetMouseButtonUp(1))
            {
                Debug.Log("slide_off");
                isSliding = false;
            }
            
            
        }
    }

    //расчет ускорения за t секунд
    private void raschet()
    {
        N = rb.velocity.magnitude;
        if (X2N >= N)
        {
            impForce = N / t;
        }
        else if (X2N < N) { impForce = 0; }

    }

    //public void HUETA() { }

    //private void OnCollisionStay2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("ground"))
    //    {
    //        lastGroundNormal = other.contacts[0].normal;
    //        onEarth = true;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground") && onEarth ==false)
        {
            lastGroundNormal = other.contacts[0].normal;
            onEarth = true;
        }

    }

    public static Vector2 lastGroundNormal = Vector2.up;

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("ground"))
    //    { onEarth = false; }

    //} //регулирует второй прыжок - при этом войде прыжок только один

    

    public override void Exit() { }

    public override void ProcessFixedUpdate()
    {
        //if (ordslide)
        //{
        if (isSliding)
        {
            if (rb.velocity.magnitude < X2N)
            {
                rb.AddForce(new Vector2((float)impForce, 0), ForceMode2D.Force);
            }

            raschet();
        }
        else if (onEarth) 
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