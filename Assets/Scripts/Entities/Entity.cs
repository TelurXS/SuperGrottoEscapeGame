using Combat;
using Entities.Components;
using Stats;
using UnityEngine;

namespace Entities
{
    public abstract class Entity : MonoBehaviour, IDamagable, IHealable, IDamageSource, IHealSource
    {
        [Header("Properties")]
        [SerializeField] private bool _isInvinsible;
        [SerializeField] private Stat _health;
        [SerializeField] private Stat _speed;
        [SerializeField] private Stat _crouchingSpeed;
        [SerializeField] private Stat _jumpHeight;

        [Header("Components")]
        protected IMovement _movement;
        protected IAnimator _animator;
        protected ICombat _combat;
        
        public bool IsInvincible => _isInvinsible;
        public Stat Health => _health;
        public Stat Speed => _speed;
        public Stat CrouchingState => _crouchingSpeed;
        public Stat JumpHeight => _jumpHeight;

        public IMovement Movement => _movement;
        public IAnimator Animator => _animator;
        public ICombat Combat => _combat;

        public System.Action Died;
        public System.Action<Stat, IDamageSource> Hurted;
        public System.Action<Stat, IHealSource> Healed;

        public abstract void InitializeComponents();

        private void Awake()
        {
            InitializeComponents();
        }

        public virtual void TakeDamage(float value, IDamageSource source)
        {
            if (_isInvinsible)
                return;
            
            _health.Remove(value);
            Hurted?.Invoke(_health, source);

            if (_health.IsEmpty)
                Kill();
        }

        public virtual void Kill()
        {
            Died?.Invoke();
            Destroy(gameObject);
        }

        public void Heal(float value, IHealSource source)
        {
            _health.Add(value);
            Healed?.Invoke(_health, source);
        }
    }

}
