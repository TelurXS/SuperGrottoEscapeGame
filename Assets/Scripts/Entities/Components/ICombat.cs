using Combat;
using System;

namespace Entities.Components
{
    public interface ICombat
    {
        Combat.Action Action { get; }
        float Cooldown { get; }

        System.Action<float> CooldownStarted { get; set; }
        System.Action<float> CooldownChanged { get; set; }

        void SetCooldown(float value);

        void PerformAction(Entity source);
        bool TryPerformAction(Entity source);
        bool CanPerform(Entity source);
    }
}