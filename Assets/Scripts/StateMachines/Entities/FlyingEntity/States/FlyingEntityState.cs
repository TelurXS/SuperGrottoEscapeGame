using Entities;

namespace StateMachines.Entities.States
{
    public abstract class FlyingEntityState : AggressiveEntityState
    {
        protected FlyingEntityStateMachine StateMachine;
        protected FlyingEntityStateFabric StateFabric;

        public FlyingEntityState(AggressiveEntity entity, FlyingEntityStateMachine stateMachine, FlyingEntityStateFabric stateFabric) : base(entity)
        {
            StateMachine = stateMachine;
            StateFabric = stateFabric;
        }
    }
}