using Combat;
using System;
using UnityEngine;

namespace Entities.Components
{
    public interface IMovement 
    {
        bool IsGrounded { get; }
        bool IsNotGrounded { get; }
        bool IsFalling { get; }
        bool IsNotFalling { get; }

        Vector2 Orientation { get; }
        Vector2 Position { get; }
        Quaternion Rotation { get; }
        Vector2 Velocity { get; }

        Action<Vector2> OrientationChanged { get; set; }

        BoxCollider2D Collider { get; }

        void Move(Vector2 direction, float speed);
        void ResetVelocity();
        void Throw(Vector2 direction, float speed);
        void Rotate(Vector2 direction);
        void Jump(float height);

        float DistanceTo(Entity entity);
        Vector2 DirectionTo(Entity entity);
    }
}