using Entities.Players;
using UnityEngine;

namespace StateMachines.Players.States
{
    public class PlayerJumpingState : PlayerIdleState
    {
        public PlayerJumpingState(Player player, PlayerStateMachine stateMachine, PlayerStateFabric stateFabric) : base(player, stateMachine, stateFabric)
        {
        }

        public override void CheckTransistions()
        {
            if (Player.Movement.IsFalling)
            {
                StateMachine.ChangeState(StateFabric.Falling);
                return;
            }
        }

        public override void OnEnter()
        {
            Player.Animator.Play("Jump");
            Player.Movement.Jump(Player.JumpHeight.Value);
        }

        public override void OnUpdate()
        {
            Vector2 direction = Player.Input.Movement.GetDirection();
            Player.Movement.Move(direction, Player.Speed.Value);

            if (Player.Input.Attack.IsPressed)
            {
                Player.Combat.TryPerformAction(Player);
            }
        }
    }
}