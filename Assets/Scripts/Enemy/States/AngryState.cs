using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class AngryState : BaseState
    {
        public AngryState(Movement movement, AnimatorHandler animator, StationBehaviour stationBehaviour)
            : base(movement, animator, stationBehaviour)
        {

        }
        public override void Enter()
        {
            SetAngrySpeed();
        }
        public override void Exit()
        {
            
        }
        public override void Update()
        {
            base.Update();
            ChangeState();
        }
        private void SetAngrySpeed()
        {
            movement.currentSpeed = movement.angrySpeed;
        }
        private void ChangeState()
        {
            if (stationBehaviour.IsDirty)
                stationBehaviour.SwitchState<DirtyState>();
            else if (!stationBehaviour.IsAngry)
                stationBehaviour.SwitchState<IdleState>();
        }        
    }
}