using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour {
	public AudioClip start;
	public AudioClip loop;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		audio.loop = true;
		StartCoroutine(MusicPlaying());
	}
	
	IEnumerator MusicPlaying(){
		audio.clip = start;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = loop;
        audio.Play();
	}
}
