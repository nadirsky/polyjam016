using UnityEngine;
using System.Collections;

public class GrowthPlantsSpell : Spell {
	
	public override void ActivateSpel()
	{
		base.ActivateSpel ();
		Debug.Log ("Aktywuje czar wzrostu roslin");
		
	}
	
	public override void RunSpell()
	{
		base.RunSpell ();
		Debug.Log ("Wykonuje czar wzrostu roslin");
	}
}

