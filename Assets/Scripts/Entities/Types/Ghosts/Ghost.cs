using Entities.Components;
using Entities.Ghosts.Components;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(EntityCombat))]
    [RequireComponent(typeof(FlyingEntityMovement))]
    [RequireComponent(typeof(EntityAnimator))]
    [RequireComponent(typeof(PlayerFinder))]
    public class Ghost : AggressiveEntity
    {
        public override void InitializeComponents()
        {
            _animator = GetComponent<EntityAnimator>();
            _movement = GetComponent<FlyingEntityMovement>();
            _combat = GetComponent<EntityCombat>();
            _targetFinder = GetComponent<PlayerFinder>();
        }
    }
}