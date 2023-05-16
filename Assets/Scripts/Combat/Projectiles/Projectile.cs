using Entities;
using UnityEngine;

namespace Combat
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Projectile : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private BoxCollider2D _collider;

        private Entity _source;
        private ProjectileAttack _attack;

        public Entity Source => _source;
        public ProjectileAttack Attack => _attack;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<BoxCollider2D>();
        }

        private void FixedUpdate()
        {
            transform.right = _rigidbody.velocity;
        }

        public void Initialize(Entity entity, ProjectileAttack attack)
        {
            _source = entity;
            _attack = attack;
        }

        public void Throw(Vector2 direction)
        {
            _rigidbody.AddForce(direction, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Entity entity))
            {
                if (entity == _source) 
                    return;
                
                _attack.OnEntityHit(this, _source, entity);
            }
            else _attack.OnWallHit(this); 
        }
    }
}