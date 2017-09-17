using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{

	private int _controlsIndex;
	private Controls CurrentControls { get { return ControlsManager.Instance.GetControls(_controlsIndex); } }

	public KeyCode increaseKeyCode;
	public KeyCode decreaseKeyCode;
	public KeyCode buttonKeyCode;
	public KeyCode nextControlKeyCode;
	public KeyCode prevControlKeyCode;

	private void Update()
	{
		if (Input.GetKey(increaseKeyCode))
		{
			if (CurrentControls != null) CurrentControls.AxisValue = 1f;
		}
		else if (Input.GetKeyDown(decreaseKeyCode))
		{
			if (CurrentControls != null) CurrentControls.AxisValue = -1f;
		}
		if (Input.GetKeyDown(buttonKeyCode))
		{
			if (CurrentControls != null) CurrentControls.ButtonPressed = true;
		}
		else if (Input.GetKeyUp(buttonKeyCode))
		{
			if (CurrentControls != null) CurrentControls.ButtonPressed = false;
		}
		if (Input.GetKeyDown(nextControlKeyCode))
		{
			NextControl();
		}
		if (Input.GetKeyDown(prevControlKeyCode))
		{
			PrevControl();
		}
	}

	private void NextControl()
	{
		CurrentControls.AxisValue = 0f;
		CurrentControls.ButtonPressed = false;
		_controlsIndex = ControlsManager.Instance.GetNext(_controlsIndex);
	}

	private void PrevControl()
	{
		CurrentControls.AxisValue = 0f;
		CurrentControls.ButtonPressed = false;
		_controlsIndex = ControlsManager.Instance.GetPrev(_controlsIndex);
	}
}
