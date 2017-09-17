using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {
	public bool isActive;
	public LayerMask _environmentLayers;

	private Transform _target;

	void Update () {
		if (_target == null) return;
		if (!isActive)
		{
			_target = null;
			return;
		}
        _target.GetComponent<Rigidbody2D>().MovePosition(transform.position);
	}

	private void OnTriggerEnter2D(Collider2D coll)
    {
		if (!isActive) return;
        if (!_environmentLayers.ContainsLayer(coll.gameObject.layer)) return;
		_target = coll.transform;
    }
}
