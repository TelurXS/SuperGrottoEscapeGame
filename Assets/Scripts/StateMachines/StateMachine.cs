using System;
using UnityEngine;

namespace StateMachines
{
    public class StateMachine : MonoBehaviour
    {
        private State _state;
        private IStateFabric _stateFabric;

        public Action<State> StateChanged;

        private void Awake()
        {
            InitializeComponents();
        }

        public virtual void InitializeComponents()
        {
            if (TryGetComponent(out IStateFabric stateFabric))
            {
                _stateFabric = stateFabric;
            }
            else Debug.LogAssertion("StateMachine is require a StateFabric");
        }

        private void Start()
        {
            ChangeState(_stateFabric.Default);
        }

        private void Update()
        {
            _state.CheckTransistions();
            _state.OnUpdate();
        }

        private void LateUpdate()
        {
            _state.OnLateUpdate();
        }

        public void ChangeState(State state) 
        {
            _state?.OnExit();
            _state = state;
            StateChanged?.Invoke(state);
            _state?.OnEnter();
        }
    }
}