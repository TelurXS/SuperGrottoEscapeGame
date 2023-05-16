using Entities.Components;
using Stats;
using System;
using UnityEngine;

namespace Entities
{
    public abstract class AggressiveEntity : Entity
    {
        [SerializeField] private Stat _aggroRadius;
        [SerializeField] private Stat _attackRadius;

        protected ITargetFinder _targetFinder;

        private Entity _target;

        public Stat AggroRadius => _aggroRadius;
        public Stat AttackRadius => _attackRadius;

        public Entity Target => _target;
        public ITargetFinder TargetFinder => _targetFinder;

        public Action<Entity> TargerChanged;

        public void SetTarget(Entity target)
        {
            _target = target;
            TargerChanged?.Invoke(_target);
        }
    }
}