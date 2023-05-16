using UnityEngine;

namespace Entities.Utils
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class EntitySpriteFlipper : MonoBehaviour
    {
        [SerializeField] private Entity _entity;

        private SpriteRenderer _sprite;

        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _entity.Movement.OrientationChanged += FlipSprite;
        }

        private void OnDisable()
        {
            _entity.Movement.OrientationChanged -= FlipSprite;
        }

        private void FlipSprite(Vector2 orientation)
        {
            _sprite.flipX = orientation.x < 0;
        }
    }
}