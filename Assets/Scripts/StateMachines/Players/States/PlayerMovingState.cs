using Entities.Players;
using UnityEngine;

namespace StateMachines.Players.States
{
    public class PlayerMovingState : PlayerState
    {
        public PlayerMovingState(Player player, PlayerStateMachine stateMachine, PlayerStateFabric stateFabric) : base(player, stateMachine, stateFabric)
        {
        }

        public override void OnEnter()
        {
            Player.Animator.Play("Run");
        }

        public override void CheckTransistions()
        {
            if (Player.Input.Movement.IsReleased)
            {
                StateMachine.ChangeState(StateFabric.Idle);
                return;
            }

            if (Player.Input.Jump.IsPressed && Player.Movement.IsGrounded)
            {
                StateMachine.ChangeState(StateFabric.Jumping);
                return;
            }

            if (Player.Movement.IsNotGrounded && Player.Movement.IsFalling)
            {
                StateMachine.ChangeState(StateFabric.Falling);
                return;
            }
        }

        public override void OnUpdate()
        {
            Vector2 direction = Player.Input.Movement.GetDirection();

            Player.Movement.Move(direction, Player.Speed.Value);
            Player.Movement.Rotate(direction);

            if (Player.Input.Attack.IsPressed)
            {
                Player.Combat.TryPerformAction(Player);
            }
        }
    }
}