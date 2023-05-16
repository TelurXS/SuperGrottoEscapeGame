using Entities;
using TMPro;
using UnityEngine;

namespace UI
{
    public class OnDeathTextFader : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _fadingSpeed;

        private bool isFading = false;

        private void Start()
        {
            _entity.Died += StartFading;
        }

        private void OnDisable()
        {
            _entity.Died -= StartFading;
        }

        private void StartFading()
        {
            isFading = true;
        }

        private void Update()
        {
            if (isFading)
            {
                Color color = _text.color;
                color.a += Time.deltaTime * _fadingSpeed;
                _text.color = color;
            }
        }
    }
}