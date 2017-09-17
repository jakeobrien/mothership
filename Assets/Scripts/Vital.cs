using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Vital {
    [Range(0, 1f)] public float value = 1f;
    public float speedOfDepletion = 1f;
    public Slider mySlider;
    public Vital(float val, float speedOfD) {
        this.value = val;
        this.speedOfDepletion = speedOfD;
    }
}
