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
	private AudioPool aPool;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		_msInput = GetComponentInParent<MothershipInput>();
		aPool = GetComponent<AudioPool>();
		audio = aPool.GetAudioSourceFromPool();
		audio.loop = true;
	}

	// Update is called once per frame
	void Update () {
		if(_msInput.ArmRotation != 0){
			ArmSound();
		}
		if(_msInput.Movement != 0){
			audio.clip = walk;
			audio.Play();
		}else{
			audio.loop = false;
		}
		/*if(_msInput.magnet == something){
			audio.PlayOneShot(clampSoft);
		}*/
	}

	public void ArmSound(){
		audio.clip = armStart;
        audio.PlayOneShot(armStart);
	}

	public void BoobSquirt(){
		audio.clip = boobSquirtStart;
        	audio.Play();
	}

	public void StopRobotSounds(){
		audio.Stop();
	}
}
