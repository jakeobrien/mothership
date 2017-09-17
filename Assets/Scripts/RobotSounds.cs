using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSounds : MonoBehaviour {
	private MothershipInput _msInput;
	public AudioClip armStart;
	public AudioClip armLoop;
	public AudioClip clampHard;
	public AudioClip clampSoft;
	public AudioClip boobRefill;
	public AudioClip boobSquirtStart;
	public AudioClip boobSquirtLoop;
	public AudioClip lullaby;
	public AudioClip walk;
	public AudioSource audio;
	public AudioSource armSource;
	public AudioSource boobSource;
	// Use this for initialization
	void Start () {
		_msInput = GetComponentInParent<MothershipInput>();

	}

	// Update is called once per frame
	void Update () {
		if(_msInput.ArmRotation != 0){
			ArmSound();
		}
		if(Mathf.Abs(_msInput.Movement)>0.1f){
			audio.clip = walk;
			if(!audio.isPlaying)
				audio.Play();
		}else{
			audio.Pause();
		}
		/*if(_msInput.magnet == something){
			audio.PlayOneShot(clampSoft);
		}*/
	}

	public void ArmSound(){
		armSource.clip = armStart;
        armSource.PlayOneShot(armStart);
	}

	public void BoobSquirt(){
		audio.loop = true;
		boobSource.clip = boobSquirtStart;
        boobSource.PlayOneShot(boobSquirtStart);
	}

	public void StopArmSound(){
		if(armSource.isPlaying)
			armSource.Stop();
	}
}
