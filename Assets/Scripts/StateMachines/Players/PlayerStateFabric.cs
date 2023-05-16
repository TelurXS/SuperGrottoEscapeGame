using Entities.Players;
using StateMachines.Players.States;
using UnityEngine;

namespace StateMachines.Players
{
    [RequireComponent(typeof(PlayerStateMachine))]
    [RequireComponent(typeof(Player))]
    public class PlayerStateFabric : MonoBehaviour, IStateFabric
    {
        private PlayerStateMachine _stateMachine;
        private Player _player;

        private void Awake()
        {
            _stateMachine = GetComponent<PlayerStateMachine>();
            _player = GetComponent<Player>();
        }

        public State Idle => new PlayerIdleState(_player, _stateMachine, this);
        public State Moving => new PlayerMovingState(_player, _stateMachine, this);
        public State Jumping => new PlayerJumpingState(_player, _stateMachine, this);
        public State Falling => new PlayerFallingState(_player, _stateMachine, this);
        public State Crouching => new PlayerCrouchingState(_player, _stateMachine, this);

        public State Default => Idle;
    }
}