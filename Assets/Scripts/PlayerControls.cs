using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

	private int _controlsIndex;
	private Controls CurrentControls { get { return ControlsManager.Instance.Mappings[_controlsIndex].controls; } }

	private void OnEnable()
	{
		var input = GetComponent<PlayerInput>();
		input.AxisUp += AxisUp;
		input.AxisDown += AxisDown;
		input.ButtonPress += ButtonPress;
		input.NextControl += NextControl;
		input.PrevControl += PrevControl;

	}

	private void OnDisable()
	{
		var input = GetComponent<PlayerInput>();
		input.AxisUp -= AxisUp;
		input.AxisDown -= AxisDown;
		input.ButtonPress -= ButtonPress;
		input.NextControl -= NextControl;
		input.PrevControl -= PrevControl;
	}

	private void AxisUp()
	{
		if (CurrentControls != null) CurrentControls.Increase();
	}

	private void AxisDown()
	{
		if (CurrentControls != null) CurrentControls.Decrease();
	}

	private void ButtonPress()
	{
		if (CurrentControls != null) CurrentControls.ButtonPress();
	}

	private void NextControl()
	{
		_controlsIndex = ControlsManager.Instance.GetNext(_controlsIndex);
	}

	private void PrevControl()
	{
		_controlsIndex = ControlsManager.Instance.GetPrev(_controlsIndex);
	}

}
