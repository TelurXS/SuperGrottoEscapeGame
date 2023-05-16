using Entities.Components;
using Entities.Ghosts.Components;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(FlyingEntityMovement))]
    [RequireComponent(typeof(EntityAnimator))]
    [RequireComponent(typeof(EyeCombat))]
    [RequireComponent(typeof(PlayerFinder))]
    public class Eye : AggressiveEntity
    {
        public override void InitializeComponents()
        {
            _movement = GetComponent<FlyingEntityMovement>();
            _animator = GetComponent<EntityAnimator>();
            _combat = GetComponent<EyeCombat>();
            _targetFinder = GetComponent<PlayerFinder>();
        }
    }
}