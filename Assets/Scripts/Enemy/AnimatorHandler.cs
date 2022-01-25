using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class AnimatorHandler : MonoBehaviour
    {
        private Animator _animator;
        void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void SetDirection(int direction)
        {
            _animator.SetInteger("direction", direction);
        }

        public void SetAngryBool(bool isAngry)
        {
            _animator.SetBool("angry", isAngry);
        }

        public void SetDirtyBool(bool isDirty)
        {
            _animator.SetBool("dirty", isDirty);
        }

        public void Attack()
        {
            _animator.SetTrigger("attack");
        }
    }
}
