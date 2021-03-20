using System;
using System.Collections;
using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MoodBar : MonoBehaviour
    {
        [Header("Slider params")]
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _sliderFillImage;
        [SerializeField] private Image _handleImage;
        [SerializeField] private float _fillDuration;
        [SerializeField] private Color _minColor;
        [SerializeField] private Color _maxColor;
        
        [Header("Gameplay")]
        [SerializeField] private Cat _cat;
        [SerializeField] private MoodSpriteData _moodSpriteData;
        
        private void OnEnable() => _cat.OnMoodChanged += ChangedMood;

        private void Start()
        {
            _slider.maxValue = Enum.GetValues(typeof(Mood)).Length;

            ChangedMood(_cat.Mood);
        }

        public void ChangedMood(Mood mood)
        {
            StopAllCoroutines();

            _handleImage.sprite = _moodSpriteData.GetHandleSprite(mood);
            
            StartCoroutine(SliderFilling((int)mood + 1));
        }

        private IEnumerator SliderFilling(float value)
        {
            float currentValue = _slider.value;
            
            float t = 0;
            while (t < _fillDuration)
            {
                _slider.value = Mathf.Lerp(currentValue, value, t / _fillDuration);
                _sliderFillImage.color = Color.Lerp(_minColor, _maxColor, _slider.value / _slider.maxValue);
                t += Time.deltaTime;
                yield return null;
            }
        }
        
        private void OnDisable() => _cat.OnMoodChanged -= ChangedMood;
    }
}