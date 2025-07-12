using Assets.MyScripts.PlayerController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//public class PlayerSpeedController : MonoBehaviour, IState

public class PlayerSpeedControllerORDSTATE : PlayerStateBase
{
    //GameManager gameManager;


    [SerializeField] private GameObject player;
    [SerializeField] private float ORDSpeed;
    private float currentSpeed;
    [SerializeField] private GameObject ground;
    Rigidbody2D rbGROUND;
    Rigidbody2D rb;
    //private bool IsJumping = false;

    private bool ordslide = true;
    private bool onEarth = false;

    private float SCRwidth;
    private float SCRleft;
    private float SCRright;
    private float curentMousePos;

    //private float SCRuntouched;


    //[SerializeField] private Slider slider;

    //private bool shouldMoreSlide = false;

    //[SerializeField] private float impForce = 5.0f;
    //[SerializeField] private float velocity;
    //private StateMachine StateMachine;
    //private bool shouldMoreSlide = false;


    protected override void Start()
    {

        //slider.value = 0;
        base.Start();
        rb = player.GetComponent<Rigidbody2D>();
        rbGROUND = ground.GetComponent<Rigidbody2D>();

        ScreenPieaces();

        GameManager.Instance.StartGame();
        //gameManager.CurrentState = GameManager.GameState.Playing;

        //StateMachine = GetComponent<StateMachine>();
        //InputManager.Instance.OnRightClickPressed += SlideInput;
        //InputManager.Instance.OnLeftClickReleased += JumpOff;
        //InputManager.Instance.OnLeftClickPressed += JumpON;
    }
    private void ScreenPieaces() 
    {
        SCRwidth = Screen.width;
        SCRleft = SCRwidth / 3;
        SCRright = (SCRwidth / 3)*2;
        //SCRuntouched = SCRwidth / 3;

    }

    void Update()
    {
        //Debug.Log(rb.velocity.magnitude);
        //Debug.Log(SCRwidth);
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
        //Debug.Log(rb.velocity.magnitude);
        //GameManager.Instance.SLideBar();

        curentMousePos = Input.mousePosition.x;

        if (GameManager.Instance.CurrentState == GameManager.GameState.Playing)
        {

            if (Input.GetMouseButtonDown(0))
            {
                //прыжок, не трожь
                if (onEarth)
                {



                    //if (curentMousePos < SCRleft) { currentSpeed = ORDSpeed - 3; }
                    //else if (curentMousePos > SCRright) { currentSpeed = ORDSpeed + 3; }
                    //else { currentSpeed = ORDSpeed; }


                    //rb.velocity = new Vector2(0, player.transform.position.y);
                    StateMachine.ChangeState<PlayerJumpState>();
                    //onEarth = falseж //работат для двойного прыжка
                    ordslide = false;
                    return;





                }
            }
            //ускорение, не трожь!
            else if (Input.GetMouseButtonDown(1))
            {

                LevelManager.Instance.CanSLideMore();
                ordslide = false;

                //StateMachine.ChangeState<PlayerSpeedUpState>();



                //для уменьшения прогресс бара
                //if (shouldMoreSlide)
                //{
                //GameManager.Instance.SlideBarDown();
                //}

            }
            else
            {
                ordslide = true;
                //GameManager.Instance.SLideBar(); 
                LevelManager.Instance.SLideBar();

                Debug.Log(currentSpeed);

                if (onEarth)
                {
                    if (curentMousePos < SCRleft) { currentSpeed = ORDSpeed - 3; }
                    else if (curentMousePos > SCRright) { currentSpeed = ORDSpeed + 3; }
                    else { currentSpeed = ORDSpeed; }
                }


                //if (curentMousePos < SCRleft) { currentSpeed -= 1; }
                //else if (curentMousePos > SCRright) { currentSpeed += 1; }
                //else { currentSpeed = ORDSpeed; }
            }
        }

        //{ IsJumping = true; }

        //if (InputManager.Instance.OnRightClickPressed)
        //{
        //if (IsJumping)
        //{
        //StateMachine.ChangeState<PlayerJumpState>();
        ////onEarth = false;
        //return;
        //}
        //onEarth = false;
        //}



    }

    //public void HUETA() { }

    private void OnCollisionStay2D(Collision2D other)
    {

        if (ground = other.gameObject)
        { onEarth = true; } 


        //// Now you can get components from the collided object
        //Rigidbody2D rb = ground.GetComponent<Rigidbody2D>();

        //if (other == ground.GetComponent<Collision2D>())
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (ground = other.gameObject)
        { onEarth = false; }

    } //регулирует второй прыжок - при этом войде прыжок только один



    public override void Exit() { }

    public override void ProcessFixedUpdate()
    {
        if (ordslide)
        {
            rb.velocity = rb.velocity.normalized * currentSpeed;
            //Input.mousePosition;
            //Screen.width;

        }
        if (ordslide == false) { rb.velocity = new Vector2(0, 0); }
        //LevelManager.Instance.SLideBar();
    }


    
}