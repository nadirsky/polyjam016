using UnityEngine;
using System.Collections;

public class AIBotBehaviour : AIBehaviour {


	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag (DestinationTag)) 
		{
			//Debug.Log("Dupa");
			goToBase = true;
			
			//rig2d.velocity = Vector3.zero;
			
		}
		
		if (other.CompareTag (DestinationTag)) 
		{
			//Debug.Log("Dupa");
			goToBase = true;
			
			//rig2d.velocity = Vector3.zero;
			
		}
		
		if (other == mainBaseCol && goToBase == true) 
		{
			goToBase = false;

			meatMag.DoladujManeDrugiemu();
			//magMany.DoladujMane();
			//rig2d.velocity = Vector3.zero;
			
			
		}
		
		//if (other.CompareTag (DestinationTag))
		//goToBase = true;
	}
}
