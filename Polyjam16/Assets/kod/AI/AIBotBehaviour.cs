using UnityEngine;
using System.Collections;

public class AIBotBehaviour : AIBehaviour {


	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag (DestinationTag)) 
		{
			goToBase = true;
		}
		
		if (other.CompareTag (DestinationTag)) 
		{
			goToBase = true;		
		}
		
		if (other == mainBaseCol && goToBase == true) 
		{
			goToBase = false;

			meatMag.AddSomeMeatToSecondPlayer();

		}
	}
}
