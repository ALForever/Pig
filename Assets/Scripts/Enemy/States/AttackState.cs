using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class AttackState : BaseState
    {
        public AttackState(Movement movement, AnimatorHandler animator, StationBehaviour stationBehaviour)
            : base(movement, animator, stationBehaviour)
        {

        }

        public override void Enter()
        {
            SetAttackSpeed();
            animator.Attack();
        }
        public override void Exit()
        {
            
        }
        public override void Update()
        {
            base.Update();
            ChangeState();
        }
        private void SetAttackSpeed()
        {
            movement.currentSpeed = movement.attackSpeed;
        }
        private void ChangeState()
        {
            if (stationBehaviour.IsDirty)
                stationBehaviour.SwitchState<DirtyState>();
        }
    }
}