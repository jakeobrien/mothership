using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Controls
{

	public float changeRate;

	private float _value;
	public float Value { get { return _value; } }

	public void Increase()
	{
		_value = Mathf.Clamp(_value + changeRate, -1f, 1f);
	}

	public void Decrease()
	{
		_value = Mathf.Clamp(_value - changeRate, -1f, 1f);
	}

	public void ButtonPress()
	{

	}

}
