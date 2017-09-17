using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Flags]
public enum NeedType { food = 1, sleep = 2, poop = 4,}

public class BabyBehavior : MonoBehaviour {

    public GameObject gameOverPanel;
    public float gameOverDelay = 1f;

    [System.Serializable]
    public class Need
    {
        public NeedType type;
        public Vital vital;
    }

    public Slider grumpySlider;
    public float grumpySliderDecrementRate;

    [SerializeField]
    public Need[] _needs;

    private void Start() {
        //gameOverPanel.SetActive(false);
        foreach(Need need in _needs) {
            need.vital.value = 1f;
        }
        grumpySlider.value = 1f;
        StartCoroutine(GameSession());
    }

    IEnumerator GameSession() {
        bool inSession = true;
        while (inSession) {
            foreach (Need need in _needs) {
                need.vital.value -= need.vital.speedOfDepletion * Time.deltaTime;
                need.vital.mySlider.value = need.vital.value;
                if (need.type == NeedType.poop) { if (need.vital.value <= 0) { PoopTrigger(); need.vital.value = 1f; } } else if (need.vital.value <= 0) { inSession = false; } else if (need.vital.value <= 0.5f) { grumpySlider.value -= grumpySliderDecrementRate; if (grumpySlider.value <= 0) { inSession = false; } }
            }
            yield return null;
        }
        Invoke("BabyFail", gameOverDelay);
	}

    private void PoopTrigger() {
        print("Im Pooping!");
    }

    public void RefillVital(int val) {
        if(_needs[val].vital.value != 0)
        _needs[val].vital.value = 1f;
    }

    void BabyFail() {
        //gameOverPanel.SetActive(true);
        print("GameOver!");
    }
}