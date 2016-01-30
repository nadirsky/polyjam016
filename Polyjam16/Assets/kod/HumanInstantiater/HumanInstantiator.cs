using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanInstantiator : MonoBehaviour {

	List<AIBehaviour> humans = new List<AIBehaviour>();
	public int maxHumans = 20;

	public int maxPlayersToAttack = 10;
	public int playerNo;

	public GameObject humanToInstantiate;
	public Transform spawnPoint;

	public GameObject destinationToSet;
	public GameObject mainBaseToSet;

	public GameObject oponentBase;



	// Use this for initialization
	void Awake () {
	
		for (int i =0; i<maxHumans; i++) 
		{
			AIBehaviour ob = Instantiate(humanToInstantiate).GetComponent<AIBehaviour>();
			ob.InitGame (destinationToSet, mainBaseToSet);
			ob.playerNo = playerNo;

			humans.Add(ob);
			ob.gameObject.SetActive(false);

		}
		
		
	}

	public List<AIBehaviour> GetAiBehaviourList()
	{
		return humans;
	}

	public bool InstantiatePlayer()
	{
		for (int i =0; i<humans.Count; i++) {
			if(!humans[i].gameObject.activeSelf)
			{
				humans[i].SetStartPostion(spawnPoint.position);
				humans[i].InitGame(destinationToSet, mainBaseToSet);
				humans[i].gameObject.SetActive(true);
				return true;
			}
		}
		SetAttack ();
		return false;

		//tablica ma wszystkie elementy



	}


	void SetAttack()
	{
		for (int i =0; i < maxPlayersToAttack; i++) 
		{
			humans[i].InitGame(oponentBase, mainBaseToSet);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
