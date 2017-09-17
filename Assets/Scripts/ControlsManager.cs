using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{

	private static ControlsManager _instance;
	public static ControlsManager Instance { get { return _instance; } }

	public enum ControlType
	{
		Movement,
		RotateArm,
		OpenCloseClaw,
		SingLullaby,
		SecreteMilk
	}

	[System.Serializable]
	public class ControlMapping
	{
		public ControlType type;
		public Controls controls;
	}

	[SerializeField]
	private ControlMapping[] _mappings;
	public ControlMapping[] Mappings { get { return _mappings; } }

	private void Awake()
	{
		_instance = this;
	}

	public int GetNext(int current)
	{
		var next = current++;
		if (current >= _mappings.Length) next = 0;
		return next;
	}

	public int GetPrev(int current)
	{
		var prev = current--;
		if (current < 0) prev = _mappings.Length - 1;
		return prev;
	}

}
