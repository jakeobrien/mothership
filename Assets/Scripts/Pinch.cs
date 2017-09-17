﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinch : MonoBehaviour {
	private Rigidbody2D rb;
	private Sprite sprite;
	public float torque = 2f;
	public float movement;
	private MothershipInput _msInput;
	// Use this for initialization
	void Start () {
		_msInput = GetComponentInParent<MothershipInput>();
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>().sprite;
		Debug.Log(sprite.pivot);
		rb.centerOfMass = new Vector2(0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		movement = _msInput.OpenCloseClaw * torque;
		rb.AddTorque(movement,ForceMode2D.Impulse);
	}
}