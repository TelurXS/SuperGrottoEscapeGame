using Entities;
using UnityEngine;

namespace Combat
{
    public class MeleeAttackHitbox : MonoBehaviour
    {
        private Entity _source;
        private MeleeAttack _attack;

        public Entity Source => _source;
        public MeleeAttack Attack => _attack;

        public void Initialize(Entity entity, MeleeAttack attack)
        {
            _source = entity;
            _attack = attack;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Entity entity))
            {
                if (entity == _source)
                    return;

                _attack.OnEntityHit(this, _source, entity);
            }
        }
    }
}