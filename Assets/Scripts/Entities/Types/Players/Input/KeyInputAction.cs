using System;
using UnityEngine;

namespace InputActions
{
    [Serializable]
    public class KeyInputAction : IInputAction
    {
        [SerializeField] private KeyCode _key;
        
        public KeyInputAction(KeyCode key)
        {
            _key = key;
        }
        
        public bool IsPressed => Input.GetKeyDown(_key);

        public bool IsReleased => Input.GetKeyUp(_key);

        public bool IsHolding => Input.GetKey(_key);
    }
}