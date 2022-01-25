using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movement : BaseMovement
    {
        [SerializeField] private float _moveSpeed = 5f;
        private float _deltaDistance = 0.05f;
        [SerializeField] private Joystick _joystick;
        private AnimatorHandler _animator;

        void Start()
        {
            _animator = GetComponent<AnimatorHandler>();
            transform.position = movePoint.position;
        }
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, _moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, movePoint.position) <= _deltaDistance)
            {
                if (_joystick.Horizontal >= 0.7f)
                {
                    Move(DirectionList.Right);
                    _animator.MoveRight();
                }

                else if (_joystick.Horizontal <= -0.7f)
                {
                    Move(DirectionList.Left);
                    _animator.MoveLeft();
                }

                else if (_joystick.Vertical >= 0.7f)
                {
                    Move(DirectionList.Up);
                    _animator.MoveUp();
                }

                else if (_joystick.Vertical <= -0.7f)
                {
                    Move(DirectionList.Down);
                    _animator.MoveDown();
                }
            }
            StandingCheck();
        }
        private void StandingCheck()
        {
            _animator.IsStanding(transform.position == movePoint.position);
        }
    }
}