using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Vital {
    [Range(0, 1f)] private float _value = 1f;
    public float speedOfDepletion = 1f;
    public Slider mySlider;
    public Vital(float val, float speedOfD) {
        _value = val;
        this.speedOfDepletion = speedOfD;
    }

    public float Value
    {
        get { return _value; }
        set
        {
            _value = Mathf.Clamp01(value);
            mySlider.value = _value;
        }
    }

}
