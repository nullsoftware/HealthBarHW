using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _animationSpeed = 40;
    [SerializeField] private PlayerInfo _playerInfo;

    private Slider _slider;
    private Coroutine _updateCoroutine;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _playerInfo.Health;
        _slider.minValue = _playerInfo.MinHealth;
        _slider.maxValue = _playerInfo.MaxHealth;
    }

    // attached to PlayerInfo.HealthChanged in editor.
    public void Refresh()
    {
        if (_updateCoroutine != null)
            StopCoroutine(_updateCoroutine);
        _updateCoroutine = StartCoroutine(UpdateBar());
    }

    private IEnumerator UpdateBar()
    {
        while (_playerInfo.Health != _slider.value)
        {
            _slider.value = Mathf.MoveTowards(
                _slider.value, _playerInfo.Health, _animationSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
