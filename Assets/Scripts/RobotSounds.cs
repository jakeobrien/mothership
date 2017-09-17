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
	// Use this for initialization
	void Start () {
		_msInput = GetComponentInParent<MothershipInput>();
		audio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if(_msInput.ArmRotation != 0){
			StartCoroutine(ArmSound());
		}

		if(_msInput.SecreteMilk){
			StartCoroutine(BoobSquirt());
		}
		if(_msInput.Movement != 0){
			audio.clip = walk;
			audio.loop = true;
			audio.Play();
		}else{
			audio.loop = false;
		}
		/*if(_msInput.magnet == something){
			audio.PlayOneShot(clampSoft);
		}*/
	}

	IEnumerator ArmSound(){
		//audio.clip = armStart;
        audio.PlayOneShot(armStart);
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = armLoop;
        audio.Play();
	}

	IEnumerator BoobSquirt(){
		//audio.clip = armStart;
        audio.PlayOneShot(boobSquirtStart);
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = boobSquirtLoop;
        audio.Play();
	}
}
