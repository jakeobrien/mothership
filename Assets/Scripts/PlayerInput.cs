using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{

	public Action AxisUp;
	public Action AxisDown;
	public Action ButtonPress;
	public Action NextControl;
	public Action PrevControl;

	public KeyCode increaseKeyCode;
	public KeyCode decreaseKeyCode;
	public KeyCode buttonKeyCode;
	public KeyCode nextControlKeyCode;
	public KeyCode prevControlKeyCode;

	private void Update()
	{
		if (Input.GetKeyDown(increaseKeyCode))
		{
			if (AxisUp != null) AxisUp();
		}
		if (Input.GetKeyDown(decreaseKeyCode))
		{
			if (AxisDown != null) AxisDown();
		}
		if (Input.GetKeyDown(buttonKeyCode))
		{
			if (ButtonPress != null) ButtonPress();
		}
		if (Input.GetKeyDown(nextControlKeyCode))
		{
			if (NextControl != null) NextControl();
		}
		if (Input.GetKeyDown(prevControlKeyCode))
		{
			if (PrevControl != null) PrevControl();
		}
	}

}
