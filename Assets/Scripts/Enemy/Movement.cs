using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Movement : BaseMovement
    {
        public float currentSpeed;
        public float idleSpeed = 3f;
        public float dirtySpeed = 2f;
        public float angrySpeed = 4f;
        public float attackSpeed = 0f;

        private float _deltaDistance = 0.05f;
        private AnimatorHandler _animator;
        public bool IsLockedDirecrion;
        public int randomDirection { get; private set; }
        private MoveDirection[] _moveDirection =
        {
            new MoveDirection(DirectionList.Right),
            new MoveDirection(DirectionList.Left),
            new MoveDirection(DirectionList.Up),
            new MoveDirection(DirectionList.Down),
        };

        private void Start()
        {
            _animator = GetComponent<AnimatorHandler>();
            transform.position = movePoint.position;
        }
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, currentSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) <= _deltaDistance)
            {
                randomDirection = GetRandomDirection();
                Move(_moveDirection[randomDirection]);
            }
        }

        private void Move(MoveDirection moveDirection)
        {
            if (!Physics2D.Raycast(movePoint.position, direction[moveDirection.directionName], moveDirection.distanceRatio, obstaclesLayer))
            {
                movePoint.localPosition += direction[moveDirection.directionName] * moveDirection.distanceRatio;
                _animator.SetDirection(randomDirection);
            }
        }
        private int GetRandomDirection()
        {
            if (!IsLockedDirecrion)
            {
                randomDirection = Random.Range(0, 4);
                return randomDirection;
            }
            else
                return randomDirection;
        }
        private class MoveDirection
        {
            public DirectionList directionName;
            public float distanceRatio;

            public MoveDirection(DirectionList directionName, float distanceRatio = 2f)
            {
                this.directionName = directionName;
                this.distanceRatio = distanceRatio;
            }
        }
    }
}