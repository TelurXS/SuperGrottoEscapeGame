using System.Collections;
using UnityEngine;

namespace Entities.Components
{
    public class WalkingEntityMovement : EntityMovement
    {
        [Header("Ground")]
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundRadius;
        [SerializeField] private LayerMask _groundLayer;

        public override bool IsGrounded => Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundLayer);
        public override bool IsFalling => Velocity.y <= 0;
        public override bool IsNotGrounded => IsGrounded is false;
        public override bool IsNotFalling => IsFalling is false;

        public override void Move(Vector2 direction, float speed)
        {
            Vector2 destination = _rigidbody.velocity.WithX(direction.x * speed);
            _rigidbody.velocity = destination;
        }

        public override void Jump(float height)
        {
            _rigidbody.velocity = _rigidbody.velocity.WithY(height);
        }
    }
}