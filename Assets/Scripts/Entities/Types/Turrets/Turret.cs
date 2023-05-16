using Entities.Components;
using UnityEngine;

namespace Entities.Turrets
{
    [RequireComponent(typeof(StandingEntityMovement))]
    [RequireComponent(typeof(EntityAnimator))]
    [RequireComponent(typeof(EntityCombat))]
    [RequireComponent(typeof(PlayerFinder))]
    public class Turret : AggressiveEntity
    {
        public override void InitializeComponents()
        {
            _movement = GetComponent<StandingEntityMovement>();
            _animator = GetComponent<EntityAnimator>();
            _combat = GetComponent<EntityCombat>();
            _targetFinder = GetComponent<PlayerFinder>();
        }
    }
}