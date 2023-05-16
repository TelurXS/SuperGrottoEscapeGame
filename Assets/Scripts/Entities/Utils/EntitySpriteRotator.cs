using Entities;
using UnityEngine;

namespace Entities.Utils
{
    public class EntitySpriteRotator : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private SpriteRenderer _sprite;

        private void Start()
        {
            _entity.Movement.OrientationChanged += RotateSprite;
        }

        private void OnDisable()
        {
            _entity.Movement.OrientationChanged -= RotateSprite;
        }

        private void RotateSprite(Vector2 orientation)
        {
            _sprite.flipY = orientation.x < 0;
            transform.right = orientation;
        }
    }
}