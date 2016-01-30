using UnityEngine;
using System.Collections;

public class AIAttack: MonoBehaviour {

	public string oponentTag = "Player";


		void OnTriggerEnter2D(Collider2D other) 
		{
//		    Debug.Log ("Other = " + other.tag + "  optag=" + oponentTag);
			if (other.tag == oponentTag) 
			{
				this.gameObject.SetActive(false);
			other.gameObject.SetActive (false);
			}
		}
		
	}

//	void OnEnable()
//	{
//
//	}
//}
