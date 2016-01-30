using UnityEngine;
using System.Collections;

public class AIAttack: MonoBehaviour {

	public string oponentTag = "Player";


		void OnTriggerEnter2D(Collider2D other) 
		{
			if (other.tag == oponentTag) 
			{
				this.gameObject.SetActive(false);
			}
		}
		
	}

//	void OnEnable()
//	{
//
//	}
//}
