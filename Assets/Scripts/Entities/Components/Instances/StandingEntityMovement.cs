using UnityEngine;

namespace Entities.Components
{
    public class StandingEntityMovement : EntityMovement
    {
        public override bool IsGrounded => true;
        public override bool IsNotGrounded => false;
        public override bool IsFalling => false;
        public override bool IsNotFalling => true;

        public override void Move(Vector2 direction, float speed) { }

        public override void Throw(Vector2 direction, float speed) { }

        public override void Jump(float height) { }
    }
}