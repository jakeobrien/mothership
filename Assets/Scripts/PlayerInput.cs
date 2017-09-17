using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{

	public string title;
	public ControlUI _controlsUI;

	private int _controlsIndex;
	private ControlMapping CurrentControlMapping { get { return ControlsManager.Instance.GetControls(_controlsIndex); } }
	private Controls CurrentControls { get { return CurrentControlMapping.controls; } }

	public KeyCode increaseKeyCode;
	public KeyCode decreaseKeyCode;
	public KeyCode buttonKeyCode;
	public KeyCode nextControlKeyCode;
	public KeyCode prevControlKeyCode;

	private float _axisValue;
	private float _axisCursor;
	public float _axisSmooth = 0.1f;
	public float _axisDamp = 0.5f;

	private void Start()
	{
		_controlsUI.playerText.text = title;
		_controlsUI.controlsText.text = CurrentControlMapping.type.ToString();
	}

	private void Update()
	{
		if (Input.GetKey(increaseKeyCode))
		{
			_axisValue = Mathf.SmoothDamp(_axisValue, 1f, ref _axisCursor, _axisSmooth);
		}
		else if (Input.GetKey(decreaseKeyCode))
		{
			_axisValue = Mathf.SmoothDamp(_axisValue, -1f, ref _axisCursor, _axisSmooth);
		}
		else
		{
			_axisValue = Mathf.SmoothDamp(_axisValue, 0f, ref _axisCursor, _axisDamp);
		}
		if (CurrentControls != null) CurrentControls.AxisValue = _axisValue;
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
		ResetControls();
		_controlsIndex = ControlsManager.Instance.GetNext(_controlsIndex);
		_controlsUI.controlsText.text = CurrentControlMapping.type.ToString();
	}

	private void PrevControl()
	{
		ResetControls();
		_controlsIndex = ControlsManager.Instance.GetPrev(_controlsIndex);
		_controlsUI.controlsText.text = CurrentControlMapping.type.ToString();
	}

	private void ResetControls()
	{
		_axisValue = 0f;
		CurrentControls.AxisValue = 0f;
		CurrentControls.ButtonPressed = false;
	}

}
