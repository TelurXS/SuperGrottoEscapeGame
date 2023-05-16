using Entities;
using UnityEngine;

namespace StateMachines.Entities.States
{
    [RequireComponent(typeof(EyeStateMachine))]
    [RequireComponent(typeof(Eye))]
    public class EyeStateFabric : FlyingEntityStateFabric
    {
        public override State Idle => new EyeIdleState(_entity, _stateMachine, this);
        public override State ChasingTarget => new EyeFightingState(_entity, _stateMachine, this);
    }
}