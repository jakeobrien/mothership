using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{

	public float movementSpeed;
	public RotateAround clawArm;
	public RotateAround tiddyArm;
	public ParticleSystem milkSplurt;
	public Rigidbody2D rb;
	public MothershipInput input;
	public Pinch topPinch;
	public Pinch bottomPinch;
	public Magnet magnet;

	private void Update()
	{
		rb.velocity = input.Movement * movementSpeed * Vector2.right;
		clawArm.input = input.ArmRotation;
		tiddyArm.input = input.TiddyArmRotation;
		if (input.SecreteMilk && !milkSplurt.isEmitting) milkSplurt.Play();
		if (!input.SecreteMilk && milkSplurt.isEmitting) milkSplurt.Stop(false, ParticleSystemStopBehavior.StopEmitting);
		magnet.isActive = input.OpenCloseClaw;
		// topPinch.input = input.OpenCloseClaw;
		// bottomPinch.input = input.OpenCloseClaw;
	}


}
