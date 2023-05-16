using Entities;
using Stats;
using UnityEngine;

namespace StateMachines.Entities.States
{
    public class EyeFightingState : FlyingEntityChasingTargetState
    {
        private bool _isDodging;
        private float _dodgingTime;
        private float _dodgingMaxTime = .7f;
        private Vector2 _dodgingDirection;

        public EyeFightingState(AggressiveEntity entity, FlyingEntityStateMachine stateMachine, FlyingEntityStateFabric stateFabric) : base(entity, stateMachine, stateFabric)
        {
        }

        public override void OnEnter()
        {
            Entity.Hurted += TryDodge;
        }

        public override void OnExit()
        {
            base.OnExit();

            Entity.Hurted -= TryDodge;
        }

        private void TryDodge(Stat health, IDamageSource source)
        {
            if (_isDodging)
                return;

            _dodgingDirection = VectorUtils.GenerateRandom(-1, 1, -.2f, .4f).normalized;
            _isDodging = true;
        }

        public override void OnUpdate()
        {
            if (_isDodging)
            {
                if (_dodgingTime > _dodgingMaxTime)
                {
                    _dodgingTime = 0f;
                    _isDodging = false;
                    return;
                }

                _dodgingTime += Time.deltaTime;
                Entity.Movement.Move(_dodgingDirection, Entity.Speed.Value * 2f);
                Entity.Movement.Rotate(_dodgingDirection);
                return;
            }

            base.OnUpdate();
        }

    }
}