using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{

	public float movementSpeed;
	public RotateAround clawArm;
	public RotateAround tiddyArm;
	public ParticleSystem milkSplurt;
	public float cooDistance;
	public Rigidbody2D rb;
	public BabyBehavior baby;
	public MothershipInput input;
	public Pinch topPinch;
	public Pinch bottomPinch;
	public Magnet magnet;
	public float milkTank = 1f;
	public float milkDepleteRate;
	public RobotSounds rs;


	private void Update()
	{
		rb.velocity = input.Movement * movementSpeed * Vector2.right;
		clawArm.input = input.ArmRotation;
		if(Mathf.Abs(input.ArmRotation)>0.1f) {
			StartArm();
		}else{
			StopArm();
		}
		tiddyArm.input = input.TiddyArmRotation;
		if (input.SecreteMilk && !milkSplurt.isEmitting && milkTank > 0f) SchtartSchplurtin();
		if ((!input.SecreteMilk || milkTank <= 0f) && milkSplurt.isEmitting) SchtopSchplurtin();
		if (input.SecreteMilk) milkTank -= milkDepleteRate * Time.deltaTime;
		if (milkTank < 0f) milkTank = 0f;
		magnet.isActive = input.OpenCloseClaw;
		CheckLullaby();
		// topPinch.input = input.OpenCloseClaw;
		// bottomPinch.input = input.OpenCloseClaw;
	}

	private void CheckLullaby()
	{
		if (!input.SingLullaby) return;
		if (baby.GetComponent<BabySpriteController>().isHeld) return;
		var dist = ((Vector2)(baby.transform.position - transform.position)).magnitude;
		if (dist > cooDistance) return;
		baby.Sleep();
	}

	private void SchtartSchplurtin()
	{
		milkSplurt.gameObject.SetActive(true);
		rs.BoobSquirt();
		milkSplurt.Play();
	}

	private void SchtopSchplurtin()
	{
		milkSplurt.Stop(false, ParticleSystemStopBehavior.StopEmitting);
		//rs.StopRobotSounds();
	}

	private void StartArm(){
		rs.ArmSound();
	}
	private void StopArm(){
		rs.StopArmSound();
	}

}
