using UnityEngine;
using System.Collections;

public class DamageSpell : Spell {

	public float damageRadius = 5f;

	public override void ActivateSpel()
	{
		base.ActivateSpel ();
		Debug.Log ("Aktywuje czar uszkodzen");
		
	}
	
	public override void RunSpell()
	{
		base.RunSpell ();
		Debug.Log ("Wykonuje czar uszkodzen");

		RaycastHit2D[] hits =  Physics2D.CircleCastAll (Camera.main.ScreenToWorldPoint (Input.mousePosition), damageRadius, Vector2.right);

		if (hits.Length > 0) {
			for(int i = 0; i<hits.Length; i++)
			{
				Debug.Log("Znalazlem " + hits[i].collider.tag);
			}
		}

	}
}
