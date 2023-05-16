using Entities;

namespace StateMachines.Entities.States
{
    public class AggressiveEntityState : State
    {
        public AggressiveEntity Entity;

        public AggressiveEntityState(AggressiveEntity entity)
        {
            Entity = entity;
        }
    }
}