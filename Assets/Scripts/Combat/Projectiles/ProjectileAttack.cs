using Entities;
using UnityEngine;

namespace Combat
{
    public abstract class ProjectileAttack : Attack
    {
        [Header("Settings")]
        [SerializeField] protected float _force;
        [SerializeField] protected float _lifeTime;
        [SerializeField] protected float _cooldown;
        [SerializeField] protected bool _destroyOnHit;
        [SerializeField] protected Projectile _prefab;

        public override void Perform(Entity source)
        {
            Projectile instance = Instantiate(_prefab, source.Movement.Position, Quaternion.identity);
            instance.Initialize(source, this);
            instance.Throw(source.Movement.Orientation * _force);
            source.Combat.SetCooldown(_cooldown);
            Destroy(instance.gameObject, _lifeTime);
        }

        public virtual void OnHit(Projectile projectile, Entity source) { }

        public virtual void OnEntityHit(Projectile projectile, Entity source, Entity entity) 
        {
            OnEntityHit(source, entity);
            OnHit(projectile, source);

            if (_destroyOnHit)
                Destroy(projectile.gameObject);
        }

        public virtual void OnWallHit(Projectile projectile)
        {
            Destroy(projectile.gameObject);
            OnHit(projectile, projectile.Source);
        }
    }
}