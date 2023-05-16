using Entities.Players;
using UnityEngine;

namespace StateMachines.Players.States
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerStateFabric stateFabric) : base(player, stateMachine, stateFabric)
        {
        }

        public override void OnEnter()
        {
            Player.Animator.Play("Idle");
        }

        public override void CheckTransistions()
        {
            if (Player.Input.Movement.IsPressed)
            {
                StateMachine.ChangeState(StateFabric.Moving);
                return;
            }

            if (Player.Input.Jump.IsPressed && Player.Movement.IsGrounded)
            {
                StateMachine.ChangeState(StateFabric.Jumping);
                return;
            }

            if (Player.Input.Crouching.IsPressed)
            {
                StateMachine.ChangeState(StateFabric.Crouching);
                return;
            }
        }

        public override void OnUpdate()
        {
            if (Player.Input.Attack.IsPressed)
            {
                if (Player.Combat.TryPerformAction(Player))
                {
                    Player.Animator.Play("Shoot");
                }
            }
        }
    }
}