using Entities;
using StateMachines.Entities.States;
using UnityEngine;

namespace StateMachines.Entities
{
    [RequireComponent(typeof(StandingEntityStateMachine))]
    [RequireComponent(typeof(AggressiveEntity))]
    public class StandingEntityStateFabric : MonoBehaviour, IStateFabric
    {
        private AggressiveEntity _entity;
        private StandingEntityStateMachine _stateMachine;

        private void Awake()
        {
            _entity = GetComponent<AggressiveEntity>();
            _stateMachine = GetComponent<StandingEntityStateMachine>();
        }

        public State Default => Idle;

        public State Idle => new StandingEntityIdleState(_entity, _stateMachine, this);
        public State Attacking => new StandingEntityAttackingState(_entity, _stateMachine, this);
    }
}

