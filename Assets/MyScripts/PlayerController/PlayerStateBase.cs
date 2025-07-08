using UnityEngine;

namespace Assets.MyScripts.PlayerController
{
    public abstract class PlayerStateBase : MonoBehaviour, IState
    {
        protected StateMachine StateMachine;

        protected virtual void Start()
        {
            StateMachine = GetComponent<StateMachine>();
        }

        public abstract void Enter();

        public abstract void Execute();

        public abstract void Exit();

        public abstract void ProcessFixedUpdate(); 
    }
}
