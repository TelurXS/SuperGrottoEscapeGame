using Entities;
using UnityEngine;

namespace Combat
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Perform(Entity source);
    }
}