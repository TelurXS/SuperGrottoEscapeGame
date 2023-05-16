using Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BossBar : MonoBehaviour
    {
        [SerializeField] private Image _image; 
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private Entity _entity;

        private void Start()
        {
            _entity.Health.Changed += ChangeFill;
        }

        private void OnEnable()
        {
            ChangeFill(_entity.Health.Value, _entity.Health.Max);
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