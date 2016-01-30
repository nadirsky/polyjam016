using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RitualScript : MonoBehaviour {

	static public RitualScript instance;
	public float timeToGenerate = 1f;
	public float timerek = 0;

	List<AIBehaviour> aiBehaviourList = new List<AIBehaviour> ();

	public Button ritualEnableBtn;
	public Button ritualDisableBtn;

	public bool firstPlayerRitual = false;
	
	public bool GetPlayerRitual
	{
		get
		{
			return firstPlayerRitual;
		}
	}
	
	public bool SetupPlayerRitual()
	{
		firstPlayerRitual = !firstPlayerRitual;
		return firstPlayerRitual;
	}


	// Use this for initialization
	void Start () {
	
		if (instance != null)
			Destroy (this);

		instance = this;

		ritualEnableBtn.onClick.AddListener (SetupRitual);
		ritualDisableBtn.onClick.AddListener (DisableRitual);

		ritualDisableBtn.gameObject.SetActive (false);;
		ritualEnableBtn.gameObject.SetActive (true);

	}


	public void AdAibehaviourToList(AIBehaviour aiBeh)
	{
		aiBehaviourList.Add (aiBeh);
	}


	public void SetupRitual()
	{
		ritualEnableBtn.gameObject.SetActive (false);
		ritualDisableBtn.gameObject.SetActive (true);
		firstPlayerRitual = true;
	}

	public void DisableRitual()
	{
		ritualEnableBtn.gameObject.SetActive (true);
		ritualDisableBtn.gameObject.SetActive (false);
		RemoveAiFromRitual ();
		firstPlayerRitual = false;
	}


	void RemoveAiFromRitual()
	{
		for (int i =0; i<aiBehaviourList.Count; i++) {
			aiBehaviourList[i].BreakRitual();
			//Debug.Log("Usuwama " + i );

		}

		aiBehaviourList.Clear();
	}
	// Update is called once per frame
	void Update () {
	

		if (aiBehaviourList.Count > 0) {
			timerek += Time.deltaTime;

			while(timerek >= timeToGenerate)
			{
				timerek = timerek - timeToGenerate;

				ManaStock.instance.GenerateMana(aiBehaviourList.Count);

			}
		}
	}
}
