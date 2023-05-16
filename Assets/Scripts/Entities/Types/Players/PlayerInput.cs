using InputActions;
using UnityEngine;

namespace Entities.Players.Components
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private KeyInputAction _jump;
        [SerializeField] private KeyInputAction _attack;
        [SerializeField] private KeyInputAction _crouching;
        [SerializeField] private VectorInputAction _movement;

        public KeyInputAction Jump => _jump;
        public KeyInputAction Attack => _attack;
        public KeyInputAction Crouching => _crouching;
        public VectorInputAction Movement => _movement;
    }
}