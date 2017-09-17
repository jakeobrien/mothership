using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum States { feeding = 1 << 0, hungry = 1 << 1, normal = 1 << 2, pooping = 1 << 3, sleeping = 1 << 4 , sleepy = 1 << 5 }

public class BabySpriteController : MonoBehaviour {
    public Sprite[] faceSprites, bodySprites;

    public GameObject faceObject, bodyObject;

    private States currentState;

    private SpriteRenderer faceRenderer, bodyRenderer;
    private BabyBehavior myBehavior;
    private BabyBehavior.Need[] myNeeds;
    private bool inSession;

    public void Start() {
        faceRenderer = faceObject.GetComponent<SpriteRenderer>();
        bodyRenderer = bodyObject.GetComponent<SpriteRenderer>();
        myBehavior = GetComponent<BabyBehavior>();
        myNeeds = myBehavior._needs;
        inSession = true;
        StartCoroutine(FaceSession());
    }

    private IEnumerator FaceSession() {
        while (inSession) {
            foreach (BabyBehavior.Need need in myNeeds) {
                switch (need.type) {
                    case NeedType.food: { if (need.vital.Value < 0.5f) { currentState = currentState | States.hungry; } else { currentState = currentState ^ States.hungry; } } 
                        break;
                    case NeedType.sleep: { if (need.vital.Value > 0.75f) { currentState = currentState | States.sleeping; currentState = currentState ^ States.sleepy; } else if (need.vital.Value < 0.35f) { currentState = currentState | States.sleepy; currentState = currentState ^ States.sleeping; } else { currentState = currentState ^ States.sleeping; currentState = currentState ^ States.sleepy; } }
                        break;
                }
            }
            DetermineFace();
            yield return null;
        }
    } private void DetermineFace() {
        if ((currentState & States.pooping) != 0) {
            SetFaceToRender(4);
        } else if ((currentState & States.sleepy) != 0) {
            SetFaceToRender(9);
        } else if ((currentState & States.hungry) != 0) {
            SetFaceToRender(2);
        } else {
            SetFaceToRender(1);
        }
    }

    public void ShowBabyDead() {
        inSession = false;
        faceRenderer.sprite = faceSprites[0];
    }
    public void MakePoopFace() {
        currentState = currentState | States.pooping;
        Invoke("EndPoopFace", 2f);
    } private void EndPoopFace() {
        currentState = currentState ^ States.pooping;
    }

    public void ShowFeedingFace() {
        currentState = currentState | States.feeding;
    } public void EndFeedingFace() {
        currentState = currentState | States.feeding;
    }

    public void ImHeld() {
        bodyRenderer.sprite = bodySprites[1];
    } public void ImNotHeld() {
        bodyRenderer.sprite = bodySprites[0];
    }

    private void SetFaceToRender(int that) {
        faceRenderer.sprite = faceSprites[that];
    }
    private void SetBodyToRender(int that) {
        faceRenderer.sprite = faceSprites[that];
    }
}
