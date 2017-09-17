using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSounds : MonoBehaviour {
	private MothershipInput _msInput;
	public AudioClip armStart;
	public AudioClip armLoop;
	public AudioClip clampHard;
	public AudioClip clampSoft;
	public AudioClip walk;
	public AudioSource source;
	// Use this for initialization
	void Start () {
		_msInput = GetComponentInParent<MothershipInput>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
