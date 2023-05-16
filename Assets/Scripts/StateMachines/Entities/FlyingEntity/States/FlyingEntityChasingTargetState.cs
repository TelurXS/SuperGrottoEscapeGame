using Entities;
using UnityEngine;

namespace StateMachines.Entities.States
{
    public class FlyingEntityChasingTargetState : FlyingEntityState
    {
        public FlyingEntityChasingTargetState(AggressiveEntity entity, FlyingEntityStateMachine stateMachine, FlyingEntityStateFabric stateFabric) : base(entity, stateMachine, stateFabric)
        {
        }

        public override void OnEnter()
        {
            Entity.Animator.Play("Chasing");
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

            if (Entity.Movement.DistanceTo(Entity.Target) <= Entity.AttackRadius.Value)
            {
                Entity.Movement.ResetVelocity();
                Entity.Combat.TryPerformAction(Entity);
            }
            else Entity.Movement.Move(direction, Entity.Speed.Value);

            Entity.Movement.Rotate(direction);
        }

        public override void OnExit()
        {
            Entity.Movement.ResetVelocity();
        }
    }
}