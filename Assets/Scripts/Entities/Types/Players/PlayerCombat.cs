using Entities.Components;
using UnityEngine;

namespace Entities.Players.Components
{
    [RequireComponent(typeof(Player))]
    public class PlayerCombat : EntityCombat
    {
    }
}