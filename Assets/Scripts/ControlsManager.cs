using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ControlMapping
{
	public ControlType type;
	public Controls controls;
}


public class ControlsManager : MonoBehaviour
{

	private static ControlsManager _instance;
	public static ControlsManager Instance { get { return _instance; } }

	[SerializeField]
	private ControlMapping[] _mappings;
	private List<int> _taken = new List<int>() { 0, 1, 2 };
	private ControlMapping[] Mappings { get { return _mappings; } }

	private void Awake()
	{
		_instance = this;
	}

	public ControlMapping GetControls(int index)
	{
		if (index < 0 || index >= _mappings.Length) return null;
		return _mappings[index];
	}

	public Controls GetControls(ControlType type)
	{
		foreach (var mapping in _mappings)
		{
			if (mapping.type == type) return mapping.controls;
		}
		return null;
	}

	public int GetNext(int current)
	{
		var next = current;
		do
		{
			next++;
			if (next >= _mappings.Length) next = 0;
		} while (_taken.Contains(next));
		if (_taken.Contains(current)) _taken.Remove(current);
		_taken.Add(next);
		return next;
	}

	public int GetPrev(int current)
	{
		var prev = current;
		do {
			prev--;
			if (prev < 0) prev = _mappings.Length - 1;
		} while (_taken.Contains(prev));
		if (_taken.Contains(current)) _taken.Remove(current);
		_taken.Add(prev);
		return prev;
	}

}
