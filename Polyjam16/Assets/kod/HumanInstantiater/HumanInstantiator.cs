using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanInstantiator : MonoBehaviour {

	List<AIBehaviour> humans = new List<AIBehaviour>();
	public int maxHumans = 20;

	public int currentActiveHumans;

	public int maxPlayersToAttack = 10;

	public GameObject humanToInstantiate;
	public Transform spawnPoint;

	public GameObject destinationToSet;
	public GameObject mainBaseToSet;

	public GameObject oponentBase;

	public GameCondition gameCondition = null;

    public int CurrentActiveHuman
    {

        get
        {

            return currentActiveHumans;
        }
    }

	// Use this for initialization
	void Start () {
	
		for (int i =0; i<maxHumans; i++) 
		{
			AIBehaviour ob = Instantiate(humanToInstantiate).GetComponent<AIBehaviour>();
			ob.InitGame (destinationToSet, mainBaseToSet);

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
				CountHumans();
				return true;
			}


		}
		CountHumans ();
		SetAttack ();
		return false;

		//tablica ma wszystkie elementy



	}

    public void ExecuteCount()
    {
        CountHumans();
    }

	void CountHumans()
	{
		currentActiveHumans = 0;

		for (int i =0; i<humans.Count; i++) 
		{
			if (humans [i].gameObject.activeSelf) {
				//Debug.Log("Dupa");
				currentActiveHumans++;
			}
		}

		//Debug.Log ("Licze ludzi");
		//currentActiveHumans;

		//GameCondition.humansCount = currentActiveHumans;
		if (gameCondition != null) {
			gameCondition.UpdatePlayer(currentActiveHumans);
		}
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
