using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AnimatorHandler : MonoBehaviour
    {
        private Animator _animator;
        void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void MoveRight()
        {
            _animator.SetInteger("direction", 0);
        }
        public void MoveLeft()
        {
            _animator.SetInteger("direction", 1);
        }
        public void MoveUp()
        {
            _animator.SetInteger("direction", 2);
        }
        public void MoveDown()
        {
            _animator.SetInteger("direction", 3);
        }
        public void IsStanding(bool isStanding)
        {
            _animator.SetBool("stand", isStanding);
        }
    }
}
