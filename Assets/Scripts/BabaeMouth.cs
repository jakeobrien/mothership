using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabaeMouth : MonoBehaviour
{

	public BabyBehavior baby;

    private void OnParticleCollision(GameObject other)
	{
		baby.Feed();
	}

}
