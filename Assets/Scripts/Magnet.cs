using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {
	public LayerMask _environmentLayers;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D coll)
    {
        if (!_environmentLayers.ContainsLayer(coll.gameObject.layer)) return;
        coll.gameObject.transform.position = this.transform.position;
    }
}
