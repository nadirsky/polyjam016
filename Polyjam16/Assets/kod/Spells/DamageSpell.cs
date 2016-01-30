using UnityEngine;
using System.Collections;

public class DamageSpell : Spell {

	public float damageRadius = 5f;


	public override void ActivateSpel()
	{
		base.ActivateSpel ();
		//Debug.Log ("Aktywuje czar uszkodzen");
		
	}
	
	public override void RunSpell()
	{
		base.RunSpell ();
		//Debug.Log ("Wykonuje czar uszkodzen");

		BonusGiver.instance.CheckDistance (Camera.main.ScreenToWorldPoint (Input.mousePosition), damageRadius);

		//RaycastHit2D[] hits =  Physics2D.CircleCastAll (Camera.main.ScreenToWorldPoint (Input.mousePosition), damageRadius, new Vector2(1,1), 5f, 4);

		//if (hits.Length > 0) {
			//for(int i = 0; i<hits.Length; i++)
			//{
				//Debug.Log("Znalazlem " + hits[i].collider.tag);
				//if(hits[i].collider.CompareTag(playerTagToCompare) || hits[i].collider.CompareTag(compTagToCompare))
				//{
					//hits[i].collider.gameObject.SetActive(false);

					//Debug.Log("Usuwam " + hits[i].collider.name);

				//}

			//}
		//}

		//for(int i = 0; i<hits.Length; i++)

	}
}
