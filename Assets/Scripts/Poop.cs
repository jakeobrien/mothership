using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Poop : MonoBehaviour
{

	public static Action PoopExploded;

	public float _durationToExplode;
	public GameObject _explosionPrefab;
	private float _startTime;

	private void Update()
	{
		if (Time.time - _startTime > _durationToExplode)
		{
			if (PoopExploded != null) PoopExploded();
			Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

}
