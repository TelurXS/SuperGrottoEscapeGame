using Entities.Players;

namespace StateMachines.Players.States
{
    public class PlayerFallingState : PlayerState
    {
        public PlayerFallingState(Player player, PlayerStateMachine stateMachine, PlayerStateFabric stateFabric) : base(player, stateMachine, stateFabric)
        {
        }

        public override void CheckTransistions()
        {
            if (Player.Movement.IsGrounded)
            {
                StateMachine.ChangeState(StateFabric.Idle);
                return;
            }
        }

        public override void OnEnter()
        {
            Player.Animator.Play("Fall");
        }

        public override void OnUpdate()
        {
            if (Player.Input.Attack.IsPressed)
            {
                Player.Combat.TryPerformAction(Player);
            }
        }
    }
}