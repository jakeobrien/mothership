using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Flags]
public enum NeedType { food = 1, sleep = 2, poop = 4,}

public class BabyBehavior : MonoBehaviour {
    private BabySpriteController spriteController;

    public float feedRate;
    public GameObject gameOverPanel;
    public float gameOverDelay = 1f;
    private BabySound bs;

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
    public ParticleSystem poop;

    private void Start() {
        //gameOverPanel.SetActive(false);
        bs = GetComponent<BabySound>();
        spriteController = GetComponent<BabySpriteController>();
        foreach(Need need in _needs) {
            need.vital.Value = 1f;
        }
        grumpySlider.value = 1f;
        StartCoroutine(GameSession());
    }

    IEnumerator GameSession() {
        bool inSession = true;
        while (inSession) {
            foreach (Need need in _needs) {
                need.vital.Value -= need.vital.speedOfDepletion * Time.deltaTime;
                if (need.type == NeedType.poop) {
                    if (need.vital.Value <= 0) {
                         PoopTrigger();
                         need.vital.Value = 1f;
                    }
                } else if (need.vital.Value <= 0) {
                    inSession = false;
                } else if (need.vital.Value <= 0.5f) {
                    grumpySlider.value -= grumpySliderDecrementRate;
                    if (grumpySlider.value <= 0) inSession = false;
                }
            }
            yield return null;
        }
        Invoke("BabyFail", gameOverDelay);
	}

    private void PoopTrigger() {
        //poop.gameObject.SetActive(true);
        poop.Play();
        //bs.Poop();
    }

    public void RefillVital(int val) {
        if(_needs[val].vital.Value != 0)
        _needs[val].vital.Value = 1f;
    }

    public void Feed()
    {
        GetVital(NeedType.food).Value += feedRate;
        bs.Feed();
    }

    void BabyFail() {
        spriteController.ShowBabyDead();
        //gameOverPanel.SetActive(true);
        print("GameOver!");
    }

    private Vital GetVital(NeedType type)
    {
        foreach (var need in _needs)
        {
            if (need.type == type) return need.vital;
        }
        return null;
    }

}
