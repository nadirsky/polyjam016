using UnityEngine;
using System.Collections;

public class AIBotBehaviour : AIBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Resource") 
		{
			goToBase = true;
			other.gameObject.transform.position = ResourceCreator.instance.CreateResPos2 ();
		}
		if (other.tag == "Finish") 
		{
			goToBase = true;
		}

		if (other == mainBaseCol && goToBase == true) 
		{
			goToBase = false;
			if (playerNo == 2) {
				meatMag.AddSomeMeatToSecondPlayer ();
			} else {
				meatMag.AddSomeMeatToThirdPlayer ();
			}
			SetDestinationCollider();
		}

	}
}
