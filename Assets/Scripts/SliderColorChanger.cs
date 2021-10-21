using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderColorChanger : MonoBehaviour
{
    [SerializeField] private Image _sliderFill;
    [SerializeField] private Color _maxColor;
    [SerializeField] private Color _minColor;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void UpdateColor(float value)
    {
        float factor = value / _slider.maxValue;

        Color color = new Color();
        color.r = Mathf.MoveTowards(_minColor.r, _maxColor.r, factor);
        color.g = Mathf.MoveTowards(_minColor.g, _maxColor.g, factor);
        color.b = Mathf.MoveTowards(_minColor.b, _maxColor.b, factor);
        color.a = 1;

        _sliderFill.color = color;
    }
}
