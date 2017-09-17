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
	private AudioSource armSource;
	private AudioSource boobSource;
	// Use this for initialization
	void Start () {
		_msInput = GetComponentInParent<MothershipInput>();
		aPool = GetComponent<AudioPool>();
		audio = GetComponent<AudioSource>();
		armSource = aPool.GetAudioSourceFromPool();
		boobSource = aPool.GetAudioSourceFromPool();
		audio.loop = true;
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
			Debug.Log(_msInput.Movement);
		}else{
			audio.Pause();
		}
		/*if(_msInput.magnet == something){
			audio.PlayOneShot(clampSoft);
		}*/
	}

	public void ArmSound(){
		Debug.Log("still fuckin");
		armSource.clip = armStart;
        armSource.PlayOneShot(armStart);
	}

	public void BoobSquirt(){
		Debug.Log("milk");
		armSource.clip = boobSquirtStart;
        armSource.Play();
	}

	public void StopArmSound(){
		armSource.Stop();
	}
}
