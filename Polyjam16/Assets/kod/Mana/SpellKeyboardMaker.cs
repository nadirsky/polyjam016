using UnityEngine;
using System.Collections;

public class SpellKeyboardMaker : MonoBehaviour {

	SpellCaster spelCaster;
	RitualScript ritualScript;


	// Use this for initialization
	void Start () {
		spelCaster = GameObject.FindObjectOfType<SpellCaster> ();
		ritualScript = GameObject.FindObjectOfType<RitualScript> ();
	
	}

	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.A))
		{
			if(!ritualScript.GetPlayerRitual)
				ritualScript.SetupRitual();
			else
				ritualScript.DisableRitual();
		}

		if(Input.GetKeyDown(KeyCode.S))
		   {
			spelCaster.ChoseSpell(0);
		}

		if(Input.GetKeyDown(KeyCode.D))
		   {
			spelCaster.ChoseSpell(1);
		}

		if(Input.GetKeyDown(KeyCode.F))
		   {
			spelCaster.ChoseSpell(2);
		}
	
	}
}
