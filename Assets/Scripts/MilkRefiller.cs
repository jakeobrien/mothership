using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkRefiller : MonoBehaviour
{

	public Mothership mothership;
	public float milkRefillRate;
	private void OnTriggerStay2D(Collider2D coll)
	{
		var tank = coll.GetComponent<MilkTank>();
		if (tank != null) mothership.milkTank = Mathf.Clamp01(mothership.milkTank + Time.deltaTime * milkRefillRate);
	}


}
