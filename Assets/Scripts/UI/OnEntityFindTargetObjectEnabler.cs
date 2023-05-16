using Entities;
using Entities.Players;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class OnEntityFindTargetObjectEnabler : MonoBehaviour
    {
        [SerializeField] private AggressiveEntity _entity;
        [SerializeField] private GameObject _object;

        private void Start()
        {
            _entity.TargerChanged += EnableObject;
        }

        private void OnDisable()
        {
            _entity.TargerChanged -= EnableObject;
        }

        private void EnableObject(Entity target)
        {
            if (target is Player)
            {
                _object.SetActive(true);
            }
        }
    }
}