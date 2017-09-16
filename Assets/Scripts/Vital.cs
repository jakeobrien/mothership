using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vital {
    [Range(0, 1f)] public float value = 1f;
    public float speedOfDepletion = 1f;
    public Vital(float val, float speedOfD) {
        this.value = val;
        this.speedOfDepletion = speedOfD;
    }
}
