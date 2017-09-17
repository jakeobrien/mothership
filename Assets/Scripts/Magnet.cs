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
            // var babeh = _target.gameObject.GetComponent<BabySpriteController>();
            // if (babeh != null) {
            //     babeh.ImNotHeld();
            // }
			_target = null;
			return;
		}
		var rb = _target.GetComponent<Rigidbody2D>();
		if (rb == null) _target = null;
		else rb.MovePosition(transform.position);
	}

	private void OnTriggerEnter2D(Collider2D coll)
    {
        if(_target != null) { return; }
		if (!isActive) return;
        if (!_environmentLayers.ContainsLayer(coll.gameObject.layer)) return;
		_target = coll.transform;
        // var babeh = _target.gameObject.GetComponent<BabySpriteController>();
        // if (babeh!=null) {
        //     babeh.ImHeld();
        // }
    }
}
