using Entities;
using Entities.Players;
using Stats;

namespace StateMachines.Entities.States
{
    public class EyeIdleState : FlyingEntityIdleState
    {
        public EyeIdleState(AggressiveEntity entity, FlyingEntityStateMachine stateMachine, FlyingEntityStateFabric stateFabric) : base(entity, stateMachine, stateFabric)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Entity.Hurted += SetTarget;
        }

        public override void OnExit()
        {
            base.OnExit();

            Entity.Hurted -= SetTarget;
        }


        private void SetTarget(Stat health, IDamageSource source)
        {
            if (source is Player player)
            {
                Entity.SetTarget(player);
            }
        }

        public override void OnLateUpdate()
        {
            Entity.SetTarget(Entity.TargetFinder.FindTarger(Entity));
        }
    }
}