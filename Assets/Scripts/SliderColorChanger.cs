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

        Debug.Log(factor);

        Color clr = new Color();
        clr.r = Mathf.MoveTowards(_minColor.r, _maxColor.r, factor);
        clr.g = Mathf.MoveTowards(_minColor.g, _maxColor.g, factor);
        clr.b = Mathf.MoveTowards(_minColor.b, _maxColor.b, factor);
        clr.a = 1;

        _sliderFill.color = clr;
    }
}
