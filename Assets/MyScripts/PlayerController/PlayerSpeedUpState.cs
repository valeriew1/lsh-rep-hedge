using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.MyScripts.PlayerController
{
    internal class PlayerSpeedUpState: PlayerStateBase
    {
        //нынче не используется. Все через ord speed state
        [SerializeField] private GameObject player;
        Rigidbody2D rb;
        
        private bool shouldMoreSlide = false;

        private double impForce = 0;
        private double N;
        [SerializeField] private double X2N;
        [SerializeField] private double t;
        
        protected override void Start()
        {
            base.Start();
            rb = player.GetComponent<Rigidbody2D>();

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
            }
            else if (X2N < N) { impForce = 0; }

        }

        public override void Enter(){
            InputManager.Instance.OnRightClickPressed += SlideON;
            InputManager.Instance.OnRightClickReleased += SlideOff;
        }

        public override void Execute()
        {
            //LevelManager.Instance.ZeroCheking(true);
            //LevelManager.Instance.ZeroCheking();
            LevelManager.Instance.SlideBarDown();
            raschet();

            //if (Input.GetMouseButtonDown(0))
            //{
            //    //прыжок, не трожь
            //    if (onEarth)
            //    {
            //        StateMachine.ChangeState<PlayerJumpState>();
            //        onEarth = false;
            //        return;
            //    }
            //}
        }

        public override void Exit()
        {
            InputManager.Instance.OnRightClickPressed -= SlideON;
            InputManager.Instance.OnRightClickReleased -= SlideOff;
        }

        public override void ProcessFixedUpdate()
        {
            if (shouldMoreSlide)
            {
                if (rb.velocity.magnitude < X2N)
                {
                    rb.AddForce(new Vector2((float)impForce,0), ForceMode2D.Force);
                }

            }
        }
    }
}
