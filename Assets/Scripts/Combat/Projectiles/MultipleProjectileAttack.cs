
using Entities;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Utils;
using static Unity.VisualScripting.Member;

namespace Combat
{
    [CreateAssetMenu(fileName = "Multiple Projectile Attack", menuName = "Combat/Multiple Projectile Attack")]
    public class MultipleProjectileAttack : DamageProjectileAttack
    {
        [SerializeField] private float[] _timings;
        [SerializeField] private float _executingTime;

        public override void Perform(Entity source)
        {
            DelayExecutor executor = new GameObject("Executor").AddComponent<DelayExecutor>();

            foreach (float timing in _timings) 
            {
                executor.StartCoroutine(ShootWithTiming(source, timing));
            }

            Destroy(executor.gameObject, _executingTime);
            source.Combat.SetCooldown(_cooldown);
        }

        public IEnumerator ShootWithTiming(Entity entity, float timing)
        {
            yield return new WaitForSeconds(timing);
            Shoot(entity);
        }

        public void Shoot(Entity source)
        {
            Projectile instance = Instantiate(_prefab, source.Movement.Position, Quaternion.identity);
            instance.Initialize(source, this);
            instance.Throw(source.Movement.Orientation * _force);
            Destroy(instance.gameObject, _lifeTime);
        }
    }
}
