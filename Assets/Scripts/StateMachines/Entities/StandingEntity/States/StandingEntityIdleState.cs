using Entities;
using UnityEngine;

namespace StateMachines.Entities.States
{
    public class StandingEntityIdleState : StandingEntityState
    {
        public StandingEntityIdleState(AggressiveEntity entity, StandingEntityStateMachine stateMachine, StandingEntityStateFabric stateFabric) : base(entity, stateMachine, stateFabric)
        {
        }

        public override void CheckTransistions()
        {
            if (Entity.Target is not null)
            {
                StateMachine.ChangeState(StateFabric.Attacking);
                return;
            }
        }

        public override void OnLateUpdate()
        {
            Entity.SetTarget(Entity.TargetFinder.FindTarger(Entity));
        }
    }
}