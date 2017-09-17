using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Flags]
public enum NeedType { food = 1, sleep = 2, poop = 4,}

public class BabyBehavior : MonoBehaviour {

    public static Action<string> Died;
    private BabySpriteController spriteController;

    public float feedRate;
    public GameObject gameOverPanel;
    public float gameOverDelay = 1f;
    private BabySound bs;
    public GameObject poopPrefab;

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
        while (true) {
            foreach (Need need in _needs) {
                need.vital.Value -= need.vital.speedOfDepletion * Time.deltaTime;
                if (need.type == NeedType.poop) {
                    if (need.vital.Value <= 0) {
                         PoopTrigger();
                         need.vital.Value = 1f;
                    }
                } else if (need.vital.Value <= 0) {
                    BabyFail(need.vital.deathMessage);
                    break;
                } else if (need.vital.Value <= 0.5f) {
                    grumpySlider.value -= grumpySliderDecrementRate;
                    if (grumpySlider.value <= 0)
                    {
                        BabyFail("your baby died from the grumps");
                        break;
                    }
                }
            }
            yield return null;
        }
	}

    private void PoopTrigger() {
        spriteController.MakePoopFace();
        Instantiate(poopPrefab, transform.position + Vector3.right * 2f, Quaternion.identity);
        poop.gameObject.SetActive(true);
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

    void BabyFail(string msg) {
        spriteController.ShowBabyDead();
        if (Died != null) Died(msg);
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
