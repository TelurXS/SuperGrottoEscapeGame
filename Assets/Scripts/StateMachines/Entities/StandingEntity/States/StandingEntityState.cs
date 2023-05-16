using Entities;
using UnityEngine;

namespace StateMachines.Entities.States
{
    public class StandingEntityState : AggressiveEntityState
    {
        protected StandingEntityStateMachine StateMachine;
        protected StandingEntityStateFabric StateFabric;

        public StandingEntityState(AggressiveEntity entity, StandingEntityStateMachine stateMachine, StandingEntityStateFabric stateFabric) : base(entity)
        {
            StateMachine = stateMachine;
            StateFabric = stateFabric;
        }
    }
}