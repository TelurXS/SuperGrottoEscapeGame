using Entities;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "Heal Action", menuName = "Combat/Heal Action")]
    class HealAction : Action
    {
        [SerializeField] private float value;
        [SerializeField] private float cooldown;
        [SerializeField] private GameObject effect;
        [SerializeField] private float effectLifetime;

        public override void Perform(Entity source)
        {
            source.Heal(value, source);
            source.Combat.SetCooldown(cooldown);
            SpawnEffect(source);
        }

        private void SpawnEffect(Entity entity) 
        {
            Destroy(Instantiate(effect, entity.Movement.Position, Quaternion.identity), effectLifetime);
        }
    }
}
