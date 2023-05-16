using Entities;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "Melee Attack", menuName = "Combat/Melee Attack")]
    public class MeleeAttack : Attack
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _cooldown;
        [SerializeField] private MeleeAttackHitbox _hitbox;
        [SerializeField] private float _throwForce;

        public override void Perform(Entity source)
        {
            MeleeAttackHitbox instance = Instantiate(_hitbox, source.Movement.Position, Quaternion.identity);
            instance.transform.right = source.Movement.Orientation;
            instance.Initialize(source, this);
            source.Combat.SetCooldown(_cooldown);
            Destroy(instance.gameObject, _lifeTime);
        }

        public override void OnEntityHit(Entity source, Entity entity)
        {
            entity.TakeDamage(_damage, source);
            entity.Movement.Throw(source.Movement.Orientation, _throwForce);
        }

        public virtual void OnEntityHit(MeleeAttackHitbox hitbox,Entity source, Entity entity)
        {
            OnEntityHit(source, entity);
        }

        public void SpawnHitbox(Transform transform)
        {
            Destroy(Instantiate(_hitbox, transform.position, transform.rotation), _lifeTime);
        }
    }
}