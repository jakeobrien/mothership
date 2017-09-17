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
    private bool inSession, inDistress, isPooping;

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
                if (need.type != NeedType.poop) {
                    inDistress = (need.vital.Value <= 0.5f);
                    if (inDistress) { break; }
                }
            }
            if (!isPooping) {
                DetermineFace(inDistress);
            }
            yield return null;
        }
    } private void DetermineFace(bool ans) {
        if (ans) { SetFaceToRender(7); } else { SetFaceToRender(1); }
    }

    public void ShowBabyDead() {
        inSession = false;
        faceRenderer.sprite = faceSprites[0];
    }
    public void MakePoopFace() {
        isPooping = true;
        faceRenderer.sprite = faceSprites[8];
        Invoke("EndPoopFace", 2f);
    } private void EndPoopFace() {
        isPooping = false;
    }

    public void ShowFeedingFace() {
    } public void EndFeedingFace() {
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
