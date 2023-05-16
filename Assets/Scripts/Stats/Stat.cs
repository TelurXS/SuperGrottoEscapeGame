using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Stat
    {
        [SerializeField] private float _value = 0;
        [SerializeField] private float _min = 0;
        [SerializeField] private float _max = 100;

        public Action<float, float> Changed;

        public Stat(float min, float max)
        {
            SetMin(min);
            SetMin(max);
            SetValue(max);
        }

        public float Value => _value;
        public float Max => _max;
        public float Min => _min;

        public bool IsEmpty => _value <= _min;
        public bool IsFull => _value >= _max;

        public void SetMax(float value) 
        {
            _min = value;
            SetValue(_value);
        }

        public void SetMin(float value)
        {
            _max = value;
            SetValue(_value);
        }

        public void SetValue(float value)
        {
            _value = Mathf.Clamp(value, _min, _max);
            Changed?.Invoke(_value, _max);
        }

        public void Add(float value)
        {
            SetValue(_value + value);
        }

        public void Remove(float value)
        {
            SetValue(_value - value);
        }
    }
}

