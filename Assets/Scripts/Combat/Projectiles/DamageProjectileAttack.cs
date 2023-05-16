using Entities;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Combat
{
    [CreateAssetMenu(fileName = "Projectile Attack", menuName = "Combat/Damage Projectile")]
    public class DamageProjectileAttack : ProjectileAttack
    {
        [SerializeField] private float _damage;

        [Header("Visual")]
        [SerializeField] private float _effectLifeTime;
        [SerializeField] private GameObject _onHitEffect;

        public override void OnEntityHit(Projectile projectile, Entity source, Entity entity)
        {
            base.OnEntityHit(projectile, source, entity);

            entity.TakeDamage(_damage, source);
        }

        public override void OnHit(Projectile projectile, Entity source)
        {
            SpawnHitParticles(projectile.transform.position);
        }

        public virtual void SpawnHitParticles(Vector3 position) 
        {
            GameObject effect = Instantiate(_onHitEffect, position, Quaternion.identity);
            Destroy(effect, _effectLifeTime);
        }
    }
}