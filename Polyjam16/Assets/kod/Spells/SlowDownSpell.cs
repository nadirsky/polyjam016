using UnityEngine;
using System.Collections;

public class SlowDownSpell : Spell {

	public float moveDowno = -2f;
	public float damageRadius = 5f;

	public override void ActivateSpel()
	{
		base.ActivateSpel ();
		Debug.Log ("Aktywuje czar spowolnienia");
		
	}
	
	public override void RunSpell()
	{
		base.RunSpell ();

//		Debug.Log ("Uzywam czar spowolnienia");
//
//		RaycastHit2D[] hits =  Physics2D.CircleCastAll (Camera.main.ScreenToWorldPoint (Input.mousePosition), damageRadius, Vector2.right);
//		
//		if (hits.Length > 0) {
//			for(int i = 0; i<hits.Length; i++)
//			{
//				//Debug.Log("Znalazlem " + hits[i].collider.tag);
//				if(hits[i].collider.CompareTag(playerTagToCompare) || hits[i].collider.CompareTag(compTagToCompare))
//				{
//					//hits[i].collider.gameObject.SetActive(false);
//
//					BonusGiver.instance.CheckIfInstanceIs(hits[i].collider.GetInstanceID(), moveDowno);
//					
//				}
//				
//			}
//		}

		BonusGiver.instance.CheckDistance (Camera.main.ScreenToWorldPoint (Input.mousePosition), damageRadius, moveDowno);

	}
}
