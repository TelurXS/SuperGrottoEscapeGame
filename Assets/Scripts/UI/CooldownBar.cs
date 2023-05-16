using Entities;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CooldownBar : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Entity _entity;

        private float _maxCooldown;

        private void Start()
        {
            _entity.Combat.CooldownStarted += SetMaxCooldown;
            _entity.Combat.CooldownChanged += ChangeFill;
        }

        private void OnDisable()
        {
            _entity.Combat.CooldownStarted -= SetMaxCooldown;
            _entity.Combat.CooldownChanged -= ChangeFill;
        }

        private void SetMaxCooldown(float value)
        {
            _maxCooldown = value;
        }

        private void ChangeFill(float value)
        {
            _image.fillAmount = value / _maxCooldown;
        }
    }
}