using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class IdleState : BaseState
    {
        public IdleState(Movement movement, AnimatorHandler animator, StationBehaviour stationBehaviour)
            : base(movement, animator, stationBehaviour)
        {

        }
        public override void Enter()
        {
            SetIdleSpeed();
        }
        public override void Exit()
        {
            
        }
        public override void Update()
        {
            base.Update();
            ChangeState();
        }
        private void SetIdleSpeed()
        {
            movement.currentSpeed = movement.idleSpeed;
        }
        private void ChangeState()
        {
            if (stationBehaviour.IsDirty)
                stationBehaviour.SwitchState<DirtyState>();
            else if (stationBehaviour.IsAngry)
                stationBehaviour.SwitchState<AngryState>();
        }
    }
}