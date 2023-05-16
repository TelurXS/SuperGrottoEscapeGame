using UnityEngine;

namespace Entities
{
    public interface IHealable 
    {
        void Heal(float value, IHealSource source);
    }
}