using Entities;
using UnityEngine;

namespace StateMachines.Entities.States
{
    public class StandingEntityAttackingState : StandingEntityState
    {
        public StandingEntityAttackingState(AggressiveEntity entity, StandingEntityStateMachine stateMachine, StandingEntityStateFabric stateFabric) : base(entity, stateMachine, stateFabric)
        {
        }

        public override void CheckTransistions()
        {
            if (Entity.Target == null)
            {
                StateMachine.ChangeState(StateFabric.Idle);
                return;
            }
        }

        public override void OnUpdate()
        {
            Vector2 direction = Entity.Movement.DirectionTo(Entity.Target);

            Entity.Movement.Rotate(direction);

            if (Entity.Movement.DistanceTo(Entity.Target) <= Entity.AttackRadius.Value)
            {
                Entity.Combat.TryPerformAction(Entity);
            }
            else
            {
                Entity.SetTarget(null);
            }
        }
    }
}