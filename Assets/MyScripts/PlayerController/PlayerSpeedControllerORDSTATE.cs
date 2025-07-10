using Assets.MyScripts.PlayerController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//public class PlayerSpeedController : MonoBehaviour, IState

public class PlayerSpeedControllerORDSTATE : PlayerStateBase
{
    [SerializeField] private GameObject player;
    [SerializeField] private float currentSpeed = 3f;
    [SerializeField] private GameObject ground;
    Rigidbody2D rbGROUND;
    Rigidbody2D rb;
    //private bool IsJumping = false;

    private bool ordslide = true;
    private bool onEarth = false;



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

        //StateMachine = GetComponent<StateMachine>();
        //InputManager.Instance.OnRightClickPressed += SlideInput;
        //InputManager.Instance.OnLeftClickReleased += JumpOff;
        //InputManager.Instance.OnLeftClickPressed += JumpON;
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
        //Debug.Log(rb.velocity.magnitude);
        //GameManager.Instance.SLideBar();

        if (Input.GetMouseButtonDown(0))
        {
            //прыжок, не трожь
            if (onEarth)
            {
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
        else { 
            ordslide = true;
            //GameManager.Instance.SLideBar(); 
            LevelManager.Instance.SLideBar();
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

        }
        //LevelManager.Instance.SLideBar();
    }


    
}