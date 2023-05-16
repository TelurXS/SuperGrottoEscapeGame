using Entities;
using UnityEngine;

namespace UI
{
    public class OnDeathParticleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _lifetime;
        [SerializeField] private Entity _entity;

        private void Start()
        {
            _entity.Died += Spawn;
        }

        private void OnDisable()
        {
            _entity.Died -= Spawn;
        }

        private void Spawn()
        {
            Destroy(Instantiate(_prefab, _entity.Movement.Position, Quaternion.identity), _lifetime);
        }
    }
}
