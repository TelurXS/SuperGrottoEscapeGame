using Entities;

namespace StateMachines.Entities.States
{
    public class FlyingEntityIdleState : FlyingEntityState
    {
        public FlyingEntityIdleState(AggressiveEntity entity, FlyingEntityStateMachine stateMachine, FlyingEntityStateFabric stateFabric) : base(entity, stateMachine, stateFabric)
        {
        }

        public override void OnEnter()
        {
            Entity.Animator.Play("Idle");
        }

        public override void CheckTransistions()
        {
            if (Entity.Target is not null)
            {
                StateMachine.ChangeState(StateFabric.ChasingTarget);
                return;
            }
        }

        public override void OnLateUpdate()
        {
            Entity.SetTarget(Entity.TargetFinder.FindTarger(Entity));
        }
    }
}