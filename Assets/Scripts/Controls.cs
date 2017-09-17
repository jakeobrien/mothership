using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Controls
{

	private float _axisValue;
	public float AxisValue
	{
		get { return _axisValue; }
		set { _axisValue = value; }
	}

	private bool _buttonPressed;
	public bool ButtonPressed
	{
		get { return _buttonPressed; }
		set { _buttonPressed = value; }
	}


}
