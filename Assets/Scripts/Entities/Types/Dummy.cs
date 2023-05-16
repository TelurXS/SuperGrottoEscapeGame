using Entities.Components;
using Entities.Ghosts.Components;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(EntityCombat))]
    [RequireComponent(typeof(WalkingEntityMovement))]
    [RequireComponent(typeof(EntityAnimator))]
    public class Dummy : Entity
    {
        public override void InitializeComponents()
        {
            _animator = GetComponent<EntityAnimator>();
            _movement = GetComponent<WalkingEntityMovement>();
            _combat = GetComponent<EntityCombat>();
        }
    }
}