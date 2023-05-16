using Combat;
using Entities.Components;
using UnityEngine;

namespace Entities.Components
{
    public class EyeCombat : EntityCombat
    {
        [SerializeField] private Action[] _actions;

        public override Action Action => _actions[Random.Range(0, _actions.Length)];
    }
}