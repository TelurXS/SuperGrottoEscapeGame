using Entities.Players.Components;
using UnityEngine;

namespace Entities.Players
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerCombat))]
    public class Player : Entity
    {
        protected PlayerInput _input;

        public PlayerInput Input => _input;
        
        public override void InitializeComponents()
        {
            _movement = GetComponent<PlayerMovement>();
            _animator = GetComponent<PlayerAnimator>();
            _input = GetComponent<PlayerInput>();
            _combat = GetComponent<PlayerCombat>();
        }
    }
}