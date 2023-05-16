using UnityEngine;

namespace Entities.Utils
{
    [RequireComponent(typeof(AggressiveEntity))]
    public class EntityAggroRadiusDrawer : MonoBehaviour
    {
        [SerializeField] private AggressiveEntity _entity;

        private void OnDrawGizmos()
        {
            if (_entity is null)
                return;

            Gizmos.DrawWireSphere(_entity.transform.position, _entity.AggroRadius.Value);
        }
    }
}