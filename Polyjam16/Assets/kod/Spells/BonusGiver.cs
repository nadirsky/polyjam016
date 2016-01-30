using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BonusGiver : MonoBehaviour {

	public static BonusGiver instance;

	public HumanInstantiator[] humnaInstantiator;
	List<AIBehaviour> aiBonusBehaviourList = new List<AIBehaviour>();

	// Use this for initialization
	void Start () {
	
		if (instance != null) 
		{
			Destroy(this);
			return;
		}

		instance = this;


		for (int i= 0; i< humnaInstantiator.Length; i++) 
		{
			List<AIBehaviour> helpList = humnaInstantiator[i].GetAiBehaviourList();

			for(int j = 0; j< helpList.Count; j++)
			{
				aiBonusBehaviourList.Add(helpList[j]);
			}
		}

		Debug.Log(humnaInstantiator.Length.ToString());

	}

	public void CheckDistance(Vector2 pos, float dist)
	{
		for (int i = 0; i<aiBonusBehaviourList.Count; i++) 
		{
			if(Vector3.Distance(aiBonusBehaviourList[i].transform.position, pos) < dist)
			{
				aiBonusBehaviourList[i].gameObject.SetActive(false);
				//Debug.Log("Zamykam obiekt " + aiBonusBehaviourList[i].name);
			}
		}
	}

	public void CheckDistance(Vector2 pos, float dist, float movement)
	{
		for (int i = 0; i<aiBonusBehaviourList.Count; i++) 
		{
			if(Vector3.Distance(aiBonusBehaviourList[i].transform.position, pos) < dist)
			{
				//aiBonusBehaviourList[i].gameObject.SetActive(false);
				//Debug.Log("Zamykam obiekt " + aiBonusBehaviourList[i].name);
				if(movement > 0)
				{
					aiBonusBehaviourList[i].MakeFaster(movement);
				}
				else
				{
					aiBonusBehaviourList[i].SlowDown(-movement);
				}
			}
		}
	}


//	public void CheckIfInstanceIs(int id, float bonus)
//	{
//		//for (int i= 0; i< humnaInstantiator.Length; i++) 
////		{
////			if(humnaInstantiator[i].GetInstanceID() == id)
////			{
////				if(bonus > 0)
////				humnaInstantiator[i]
////			}
////		}
//
//		for(int i = 0; i<aiBonusBehaviourList.Count; i++)
//		{
//			if(aiBonusBehaviourList[i].GetInstanceID() == id)
//			{
//				if(bonus > 0)
//				{
//					aiBonusBehaviourList[i].MakeFaster(bonus);
//				}
//				else
//				{
//					aiBonusBehaviourList[i].SlowDown(-bonus);
//				}
//			}
//		}
//	}

	// Update is called once per frame
	void Update () {
	
	}
}
