using Entities;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Entity _entity;

        private void OnEnable()
        {
            _entity.Health.Changed += ChangeFill;
        }

        private void OnDisable()
        {
            _entity.Health.Changed -= ChangeFill;
        }

        private void ChangeFill(float value, float max) 
        {
            _image.fillAmount = value / max;
        }
    }
}

