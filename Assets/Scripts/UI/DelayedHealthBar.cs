using Entities;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DelayedHealthBar : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private Image _image;
        [SerializeField] private float _changingSpeed;
        private float _currentFill = 1f;
        private float _targetFill = 1f;

        private void LateUpdate()
        {
            if (_currentFill < _targetFill)
                return;

            _currentFill -= Time.deltaTime * _changingSpeed;
            _image.fillAmount = _currentFill;
        }

        private void Start()
        {
            _entity.Health.Changed += SetTargetFill;
        }

        private void OnEnable()
        {
            _targetFill = _entity.Health.Value / _entity.Health.Max;
        }

        private void OnDisable()
        {
            _entity.Health.Changed -= SetTargetFill;
        }

        private void SetTargetFill(float value, float max)
        {
            _targetFill = value / max;

            if (_currentFill < _targetFill)
                _currentFill = _targetFill;
        }
    }
}