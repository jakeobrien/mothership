using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkTank : MonoBehaviour
{
    public Slider milkTankSlider;
    private Mothership motherShip;

    void Start() {
        motherShip = GameObject.FindObjectOfType<Mothership>();
    }

    void Update() {
        //milkTankSlider.value = motherShip.milkTank;
    }
}