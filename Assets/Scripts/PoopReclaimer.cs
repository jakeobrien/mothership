using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopReclaimer : MonoBehaviour
{


	private void OnTriggerStay2D(Collider2D coll)
	{
		var poop = coll.GetComponent<Poop>();
		if (poop != null) Destroy(poop.gameObject);
	}

}
