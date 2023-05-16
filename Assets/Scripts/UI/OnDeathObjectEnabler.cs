using Entities;
using UnityEngine;

namespace UI
{
    public class OnDeathObjectEnabler : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private GameObject _object;

        private void Start()
        {
            _entity.Died += DisableObject;
        }

        private void OnDisable()
        {
            _entity.Died -= DisableObject;
        }

        private void DisableObject()
        {
            _object.SetActive(true);
        }
    }
}