using Entities.Players;
using UnityEngine;

namespace StateMachines.Players.States
{
    public class PlayerCrouchingState : PlayerState
    {
        private Vector2 _previousOffset;
        private Vector2 _previousScale;

        private Vector2 _crouchingOffset = new Vector2(0, -0.8f);
        private Vector2 _crouchingScale = new Vector2(0.8f, 0.8f);

        public PlayerCrouchingState(Player player, PlayerStateMachine stateMachine, PlayerStateFabric stateFabric) : base(player, stateMachine, stateFabric)
        {
        }

        public override void CheckTransistions()
        {
            if (Player.Input.Crouching.IsReleased)
            {
                StateMachine.ChangeState(StateFabric.Idle);
                return;
            }
        }

        public override void OnEnter()
        {
            _previousScale = Player.Movement.Collider.size;
            _previousOffset = Player.Movement.Collider.offset;
            Player.Movement.Collider.size = _crouchingScale;
            Player.Movement.Collider.offset = _crouchingOffset;
            Player.Animator.Play("Crouching");
        }

        public override void OnUpdate()
        {
            Vector2 direction = Player.Input.Movement.GetDirection();

            Player.Movement.Move(direction, Player.CrouchingState.Value);
            Player.Movement.Rotate(direction);
        }

        public override void OnExit()
        {
            Player.Movement.Collider.size = _previousScale;
            Player.Movement.Collider.offset = _previousOffset;
        }
    }
}