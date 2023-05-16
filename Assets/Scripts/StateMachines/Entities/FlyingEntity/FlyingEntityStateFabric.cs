using Entities;
using StateMachines.Entities.States;
using UnityEngine;

namespace StateMachines.Entities
{
    [RequireComponent(typeof(FlyingEntityStateMachine))]
    [RequireComponent(typeof(AggressiveEntity))]
    public class FlyingEntityStateFabric : MonoBehaviour, IStateFabric
    {
        protected AggressiveEntity _entity;
        protected FlyingEntityStateMachine _stateMachine;

        private void Awake()
        {
            _entity = GetComponent<AggressiveEntity>();
            _stateMachine = GetComponent<FlyingEntityStateMachine>();
        }

        public State Default => Idle;

        public virtual State Idle => new FlyingEntityIdleState(_entity, _stateMachine, this);
        public virtual State ChasingTarget => new FlyingEntityChasingTargetState(_entity, _stateMachine, this);
    }
}

