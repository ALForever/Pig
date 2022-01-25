using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public abstract class BaseState
    {
        protected readonly Movement movement;
        protected readonly AnimatorHandler animator;
        protected readonly StationBehaviour stationBehaviour;

        protected BaseState(Movement movement, AnimatorHandler animator, StationBehaviour stationBehaviour)
        {
            this.movement = movement;
            this.animator = animator;
            this.stationBehaviour = stationBehaviour;
        }

        public abstract void Enter();
        public abstract void Exit();
        public virtual void Update()
        {
            CheckAggression();
        }
        private void CheckAggression()
        {
            Vector3 position = movement.transform.position;
            Vector3 direction = movement.MovePoint.position - movement.transform.position;
            stationBehaviour.IsAngry = Physics2D.Raycast(position, direction, Mathf.Infinity, stationBehaviour.playerLayer) ? true : false;
        }
    }
}