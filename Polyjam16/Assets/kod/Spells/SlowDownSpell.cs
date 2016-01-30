using UnityEngine;
using System.Collections;

public class SlowDownSpell : Spell {
	
	public override void ActivateSpel()
	{
		base.ActivateSpel ();
		Debug.Log ("Aktywuje czar spowolnienia");
		
	}
	
	public override void RunSpell()
	{
		base.RunSpell ();

		Debug.Log ("Uzywam czar spowolnienia");
	}
}
