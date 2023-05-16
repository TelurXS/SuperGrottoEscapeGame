using Entities.Components;
using Entities.Players;
using UnityEngine;

namespace Entities.Components
{
    public class PlayerFinder : MonoBehaviour, ITargetFinder
    {
        private Collider2D[] _colliders = new Collider2D[20];

        public Entity FindTarger(AggressiveEntity source)
        {
            if (Physics2D.OverlapCircleNonAlloc(source.Movement.Position, source.AggroRadius.Value, _colliders) > 0)
            {
                foreach (Collider2D collider in _colliders)
                {
                    if (collider == null) continue;

                    collider.GetComponent<Player>();

                    if (collider.TryGetComponent(out Player player))
                    {
                        return player;
                    }
                }
            }

            return null;
        }
    }
}