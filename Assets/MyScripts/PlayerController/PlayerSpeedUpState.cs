using System;
using UnityEngine;

namespace Assets.MyScripts.PlayerController
{
    internal class PlayerSpeedUpState: PlayerStateBase
    {
        [SerializeField] private GameObject player;
        [SerializeField] private float impForce = 5.0f;
        Rigidbody2D rb;
        private bool shouldMoreSlide = false;


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
        }
        private void SlideOff()
        {
            shouldMoreSlide = false;
            StateMachine.ChangeState<PlayerSpeedControllerORDSTATE>();
        }

        public override void Enter(){}

        public override void Execute(){}

        public override void Exit(){ shouldMoreSlide = false; }

        public override void ProcessFixedUpdate()
        {
            if (shouldMoreSlide)
            {
                rb.AddForce(new Vector2(impForce, 0), ForceMode2D.Force);
                //shouldMoreSlide = false;
                
            }
        }
    }
}
