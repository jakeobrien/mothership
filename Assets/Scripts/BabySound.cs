using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySound : MonoBehaviour {
	private BabyBehavior bb;
	public AudioClip feeding;
	public AudioClip hungry;
	public AudioClip cooing;
	public AudioClip poop;
	public AudioClip sleep;
	public AudioClip sleepAngry;
	public AudioClip sleepPreAngry;
	public AudioClip upset;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		bb = GetComponentInParent<BabyBehavior>();
		audio = GetComponentInParent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Poop(){
		audio.PlayOneShot(poop);
	}
	public void Feed(){
		if(!audio.isPlaying)
			audio.PlayOneShot(feeding);
	}
}
