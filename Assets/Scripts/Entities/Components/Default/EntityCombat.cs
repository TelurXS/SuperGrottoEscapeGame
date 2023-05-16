using Combat;
using System;
using UnityEngine;

namespace Entities.Components
{
    public class EntityCombat : MonoBehaviour, ICombat
    {
        [SerializeField] private Combat.Action _action;

        private float _cooldown = 0f;

        public virtual Combat.Action Action => _action;
        public virtual float Cooldown => _cooldown;

        public System.Action<float> CooldownStarted { get; set; }
        public System.Action<float> CooldownChanged { get; set; }

        private void Update()
        {
            if (_cooldown > 0)
            {
                _cooldown -= Time.deltaTime;
                CooldownChanged?.Invoke(_cooldown);
            }
        }

        public virtual void SetCooldown(float value)
        {
            _cooldown = value;
            CooldownStarted?.Invoke(value);
        }

        public virtual bool CanPerform(Entity source)
        {
            return _cooldown <= 0f;
        }

        public virtual void PerformAction(Entity source)
        {
            Action.Perform(source);
        }

        public virtual bool TryPerformAction(Entity source)
        {
            if (CanPerform(source))
            {
                PerformAction(source);
                return true;
            }

            return false;
        }
    }
}