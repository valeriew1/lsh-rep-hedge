using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.MyScripts.PlayerController
{
    internal class PlayerSpeedUpState: PlayerStateBase
    {
        [SerializeField] private GameObject player;
        Rigidbody2D rb;
        //[SerializeField] private float impForce = 5.0f;
        //[SerializeField] private int N;

        private bool shouldMoreSlide = false;

        private double impForce = 0;
        private double N;
        [SerializeField] private double X2N;
        [SerializeField] private double t;
        
        
        //[SerializeField] private Slider slider;
        //[SerializeField] private int MaxFoodNum;
        //private int CurrentFoodNum = 0;
        

        protected override void Start()
        {
            base.Start();
            rb = player.GetComponent<Rigidbody2D>();
            InputManager.Instance.OnRightClickPressed += SlideON;
            InputManager.Instance.OnRightClickReleased += SlideOff;

        }
        private void SlideON()
        {
            shouldMoreSlide = true;
;
        }
        private void SlideOff()
        {
            shouldMoreSlide = false;
            StateMachine.ChangeState<PlayerSpeedControllerORDSTATE>();

        }

//расчет ускорения за t секунд
        private void raschet() 
        {
            N = rb.velocity.magnitude;
            if (X2N >= N)
            {
                impForce = N / t;
                //impForce = N / Math.Sqrt(Convert.ToDouble(t));
                //impForce = N / Math.Pow(Convert.ToDouble(t),2);
            }
            //else if (X2N < N) { impForce = X2N / Math.Pow(Convert.ToDouble(t), 2); }
            else if (X2N < N) { impForce = 0; }

        }

        public override void Enter(){}

        public override void Execute()
        {
            //Debug.Log(rb.velocity.magnitude);
            //if (slider)
            //    {
            //        slider.value = (float)CurrentFoodNum / MaxFoodNum;
            //    }



            //GameManager.Instance.SlideBarDown();
            ////для уменьшения прогресс бара
            //if (shouldMoreSlide)
            //{
            //    GameManager.Instance.SlideBarDown();
            ////}
            LevelManager.Instance.SlideBarDown();
            raschet();
        }

        public override void Exit() { } //shouldMoreSlide = false;

        public override void ProcessFixedUpdate()
        {
            if (shouldMoreSlide)
            {
                if (rb.velocity.magnitude < X2N)
                {
                    rb.AddForce(new Vector2((float)impForce,0), ForceMode2D.Force);
                }


                //LevelManager.Instance.SlideBarDown();

                //while()

                //raschet();
                //rb.AddForce(new Vector2(impForce, 0), ForceMode2D.Force);
                //rb.AddForce(new Vector2((float)impForce, 0), ForceMode2D.Force);

            }
        }
    }
}
