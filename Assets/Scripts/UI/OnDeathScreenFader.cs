using Entities;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class OnDeathScreenFader : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private Image _image;
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
                Color color = _image.color;
                color.a += Time.deltaTime * _fadingSpeed;
                _image.color = color;
            }
        }
    }
}