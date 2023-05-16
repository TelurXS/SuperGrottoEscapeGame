using Entities.Players;

namespace StateMachines.Players.States
{
    public class PlayerState : State
    {
        protected Player Player;
        protected PlayerStateMachine StateMachine;
        protected PlayerStateFabric StateFabric;

        public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerStateFabric stateFabric)
        {
            Player = player;
            StateMachine = stateMachine;
            StateFabric = stateFabric;
        }
    }
}