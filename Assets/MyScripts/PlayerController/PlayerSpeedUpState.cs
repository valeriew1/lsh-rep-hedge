using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.MyScripts.PlayerController
{
    internal class PlayerSpeedUpState: PlayerStateBase
    {
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
            }
            else if (X2N < N) { impForce = 0; }

        }

        public override void Enter(){}

        public override void Execute()
        {
            LevelManager.Instance.SlideBarDown();
            raschet();
        }

        public override void Exit() { }

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
