using System;
using UnityEngine;

namespace InputActions
{
    [Serializable]
    public class VectorInputAction : IInputAction
    {
        [SerializeField] private string _horizontal;
        [SerializeField] private string _vertical;

        public VectorInputAction(string horizontal, string vertical)
        {
            _horizontal = horizontal;
            _vertical = vertical;
        }
        
        public bool IsPressed => GetDirection().magnitude > 0;

        public bool IsReleased => IsPressed is false;

        public bool IsHolding => IsPressed;

        public Vector2 GetDirection()
        {
            float horizontal = Input.GetAxis(_horizontal);
            float vertical = Input.GetAxis(_vertical);
            return new Vector2(horizontal, vertical);
        }
    }
}