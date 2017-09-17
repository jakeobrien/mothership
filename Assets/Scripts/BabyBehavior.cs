using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Flags]
public enum NeedType { food = 1, sleep = 2, poop = 4,}

public class BabyBehavior : MonoBehaviour {
    [System.Serializable]
    private class Need
    {
        public NeedType type;
        public Vital vital;
    }

    [SerializeField]
    private Need[] _needs;

    public Slider grumpySlider;
    public float grumpySliderDecrementRate;

    private void Start() {
        foreach(Need need in _needs) {
            need.vital.value = 1f;
        }
        grumpySlider.value = 1f;
    }

    void Update () {
        foreach (Need need in _needs) {
            need.vital.value -= need.vital.speedOfDepletion * Time.deltaTime;
            need.vital.mySlider.value = need.vital.value;
            if(need.vital.value <= 0) { BabyFail(); }
            else if(need.vital.value <= 0.5f) { grumpySlider.value -= grumpySliderDecrementRate; if (grumpySlider.value <= 0) { BabyFail(); } }
        }
	}


    public void RefillVital(int val) {
        if(_needs[val].vital.value != 0)
        _needs[val].vital.value = 1f;
    }

    void BabyFail() {
        print("You failed to take care of baby");
    }
}