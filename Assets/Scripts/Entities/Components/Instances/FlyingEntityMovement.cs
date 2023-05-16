using Entities.Components;
using System;
using UnityEngine;

namespace Entities.Ghosts.Components
{
    public class FlyingEntityMovement : EntityMovement
    {
        public override bool IsGrounded => false;
        public override bool IsNotGrounded => true;
        public override bool IsFalling => false;
        public override bool IsNotFalling => true;

        public override void Move(Vector2 direction, float speed)
        {
            _rigidbody.velocity = direction * speed;
        }
    }
}