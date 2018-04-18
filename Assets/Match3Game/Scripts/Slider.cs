using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour {
    public Transform bar;
    float _sliderValue = 1f;
    Vector3 savedScale;
    public float minValue = 0;
    public float maxValue = 1;

    public float sliderValue
    {
        get {
            return _sliderValue;
        }
        set {
            _sliderValue = Mathf.Clamp(value, minValue, maxValue);
            if (bar) bar.transform.localScale = new Vector3(savedScale.x * normalizedSliderValue, savedScale.y, savedScale.z);
        }
    }

    public float normalizedSliderValue
    {
        get { return (_sliderValue - minValue) / (maxValue - minValue); }
    }

	void Start () {
        if (bar) savedScale = bar.localScale;
	}
}
