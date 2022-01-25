using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy
{
    public class StationBehaviour : MonoBehaviour, IStationStateSwitcher
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private AnimatorHandler _animator;
        [SerializeField] private bool _isAngry;
        public bool IsAngry
        {
            get => _isAngry;
            set
            {
                _isAngry = value;
                _animator.SetAngryBool(value);
                _movement.IsLockedDirecrion = value;
            }
        }
        [SerializeField] private bool _isDirty;
        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                _animator.SetDirtyBool(value);
                if (value)
                    currentDirtyStateDuration = defaultDirtyStateDuration;

            }
        }
        public float defaultDirtyStateDuration = 4f;
        public float currentDirtyStateDuration;
        public LayerMask playerLayer;
        private BaseState _currentState;
        private List<BaseState> _allStates;
        
        void Start()
        {
            _allStates = new List<BaseState>()
            {
                new IdleState(_movement, _animator, this),
                new DirtyState(_movement, _animator, this),
                new AngryState(_movement, _animator, this),
                new AttackState(_movement, _animator, this)
            };
            _currentState = _allStates[0];
            _currentState.Enter();
        }
        void Update()
        {
            _currentState.Update();
        }

        public void SwitchState<T>() where T : BaseState
        {
            var newState = _allStates.FirstOrDefault( state  => state is T);
            _currentState.Exit();
            _currentState = newState;
            newState.Enter();
        }
        void OnCollisionStay2D(Collision2D collision)
        {
            if (_currentState == _allStates[2] && collision.gameObject.layer == Math.Log(playerLayer.value, 2))
            {
                SwitchState<AttackState>();
            }
        }
        private void AnimationEventChangeState()//AttackEnemyAnimation
        {
            if (IsAngry)
                SwitchState<AngryState>();
            else
                SwitchState<IdleState>();
        }
    }
}