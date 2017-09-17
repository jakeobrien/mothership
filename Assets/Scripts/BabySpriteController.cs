using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySpriteController : MonoBehaviour {
    public Sprite[] babySprites;

    private SpriteRenderer myRenderer;
    private BabyBehavior myBehavior;
    private BabyBehavior.Need[] myNeeds;
    public void Start() {
        myRenderer = GetComponent<SpriteRenderer>();
        myBehavior = GetComponent<BabyBehavior>();
        myNeeds = myBehavior._needs;
        SetSpriteToRender(0);
    }

    private void Update() {
        foreach (BabyBehavior.Need need in myNeeds) {
            if (need.vital.Value <= 0.5f) {
                switch (need.type) {
                    case NeedType.food: { }
                        break;
                    case NeedType.sleep: { }
                        break;
                    case NeedType.poop: { }
                        break;
                }
            } else { }
        }
    }

    private void SetSpriteToRender(int that) {
        //myRenderer.enabled = false;
    }
}
