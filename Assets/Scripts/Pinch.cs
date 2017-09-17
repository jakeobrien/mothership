using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinch : MonoBehaviour {
	[HideInInspector]
	public float input;
	private Rigidbody2D rb;
	private Sprite sprite;
	public float torque = 2f;
	public float movement;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>().sprite;
		Debug.Log(sprite.pivot);
		rb.centerOfMass = new Vector2(0.0f, 0.0f);
	}

	// Update is called once per frame
	void Update () {
		movement = input * torque;
		rb.AddTorque(movement,ForceMode2D.Impulse);
	}
}
