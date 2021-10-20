using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _animationSpeed = 40;
    [SerializeField] private float _currentValue;

    private Slider _slider;
    
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _currentValue = _slider.value;
    }

    private void Update()
    {
        if (_currentValue != _slider.value)
            _slider.value = Mathf.MoveTowards(_slider.value, _currentValue, _animationSpeed * Time.deltaTime);
    }

    public void UpdateHealthBar(int health)
    {
        _currentValue = health;
    }
}
