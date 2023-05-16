using Entities;

namespace Combat
{
    public abstract class Attack : Action
    {
        public virtual void OnEntityHit(Entity source, Entity entity) { }
    }
}