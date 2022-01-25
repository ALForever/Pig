using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class DirtyState : BaseState
    {
        public DirtyState(Movement movement, AnimatorHandler animator, StationBehaviour stationBehaviour)
            : base(movement, animator, stationBehaviour)
        {

        }
        public override void Enter()
        {
            SetDirtySpeed();
            stationBehaviour.IsAngry = false;
        }
        public override void Exit()
        {
            stationBehaviour.IsDirty = false;
        }
        public override void Update()
        {
            if (StateTimer() <= 0)
                stationBehaviour.SwitchState<IdleState>();
        }
        private void SetDirtySpeed()
        {
            movement.currentSpeed = movement.dirtySpeed;
        }

        private float StateTimer()
        {
            return stationBehaviour.currentDirtyStateDuration -= Time.deltaTime;
        }
    }
}