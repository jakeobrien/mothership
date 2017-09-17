using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipInput : MonoBehaviour
{

	private Controls _movement;
	private Controls _armRotation;
	private Controls _openCloseClaw;
	private Controls _secreteMilk;
	private Controls _singLullaby;

	public float MovementInput
	{
		get { return _movement.AxisValue; }
	}

	public float ArmRotation
	{
		get { return _armRotation.AxisValue; }
	}

	public float OpenCloseClaw
	{
		get { return _openCloseClaw.AxisValue; }
	}

	public bool SecreteMilk
	{
		get { return _secreteMilk.ButtonPressed; }
	}

	public bool SingLullaby
	{
		get { return _singLullaby.ButtonPressed; }
	}

	private void Awake()
	{
		var controls = ControlsManager.Instance;
		_movement = controls.GetControls(ControlType.Movement);
		_armRotation = controls.GetControls(ControlType.RotateArm);
		_openCloseClaw = controls.GetControls(ControlType.OpenCloseClaw);
		_secreteMilk = controls.GetControls(ControlType.SecreteMilk);
		_singLullaby = controls.GetControls(ControlType.SingLullaby);
	}

}
