using UnityEngine;

namespace Entities.Components
{
    public class EntityAnimator : MonoBehaviour, IAnimator
    {
        [SerializeField] private Animator _animator;

        public virtual void Play(string animation)
        {
            _animator.Play(animation);
        }
    }
}