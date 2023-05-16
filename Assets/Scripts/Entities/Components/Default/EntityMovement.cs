using System;
using UnityEngine;

namespace Entities.Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class EntityMovement : MonoBehaviour, IMovement
    {
        [Header("Properties")]
        [SerializeField] protected Vector2 _orientation = Vector2.right;

        protected Rigidbody2D _rigidbody;
        protected BoxCollider2D _collider;

        public virtual bool IsGrounded => false;
        public virtual bool IsFalling => false;
        public virtual bool IsNotGrounded => false;
        public virtual bool IsNotFalling => false;

        public virtual Vector2 Position => _rigidbody.position;
        public virtual Quaternion Rotation => transform.rotation;
        public virtual Vector2 Velocity => _rigidbody.velocity;
        public virtual Vector2 Orientation => _orientation;

        public BoxCollider2D Collider => _collider;

        public Action<Vector2> OrientationChanged { get; set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<BoxCollider2D>();
        }

        public virtual void Move(Vector2 direction, float speed)
        {
        }

        public virtual void Rotate(Vector2 direction)
        {
            if (direction.x == 0)
                return;

            _orientation = direction.normalized;
            OrientationChanged?.Invoke(_orientation);
        }

        public virtual void Jump(float height)
        { 
        }

        public virtual void Throw(Vector2 direction, float speed)
        {
            _rigidbody.AddForce(direction * speed, ForceMode2D.Impulse);
        }

        public virtual void ResetVelocity()
        {
            _rigidbody.velocity = Vector2.zero;
        }

        public virtual float DistanceTo(Entity entity)
        {
            return Vector2.Distance(Position, entity.Movement.Position);
        }

        public Vector2 DirectionTo(Entity entity)
        {
            return (entity.Movement.Position - Position).normalized;

        }
    }
}