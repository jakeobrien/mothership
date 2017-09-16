using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Flags]
public enum Needs { food = 1, sleep = 2, poop = 4}

public class BabyBehavior : MonoBehaviour {

    private Dictionary<Needs, Vital> _needs = new Dictionary<Needs, Vital>();

    public Slider foodSlider, sleepSlider, poopSlider;
    [Header("Decrement Speed of each Need")]
    public float foodDecRate;
    public float sleepDecRate, poopDecRate;

    void Start () {
        _needs[Needs.food] = new Vital(1f,foodDecRate);
        _needs[Needs.sleep] = new Vital(1f, sleepDecRate);
        _needs[Needs.poop] = new Vital(1f, poopDecRate);
    }
	
	void Update () {
        foreach (var kvp in _needs) {
            kvp.Value.value -= kvp.Value.speedOfDepletion * Time.deltaTime;
            switch (kvp.Key) {
                case Needs.food: { foodSlider.value = kvp.Value.value; }
                    break;
                case Needs.sleep: { sleepSlider.value = kvp.Value.value; }
                    break;
                case Needs.poop: { poopSlider.value = kvp.Value.value; }
                    break;
            }
            if(kvp.Value.value <= 0) { BabyFail(); }
        }
	}

    public void RefillVital(int val) {
        if(_needs[(Needs)val].value != 0)
        _needs[(Needs)val].value = 1f;
    }

    void BabyFail() {
        print("You failed to take care of baby");
    }
}