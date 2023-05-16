using Entities;
using UnityEngine;

namespace UI
{
    public class OnDeathObjectDisabler : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private GameObject _object;

        private void Start()
        {
            _entity.Died += EnableObject;
        }

        private void OnDisable()
        {
            _entity.Died -= EnableObject;
        }

        private void EnableObject()
        {
            _object.SetActive(false);
        }
    }
}