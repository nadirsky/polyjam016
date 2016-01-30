using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanInstantiator : MonoBehaviour {

	List<AIBehaviour> humans = new List<AIBehaviour>();
	public int maxHumans = 20;

	public GameObject humanToInstantiate;
	public Transform spawnPoint;

	public Transform destinationToSet;
	public Transform mainBaseToSet;



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

	public void InstantiatePlayer()
	{
		for (int i =0; i<humans.Count; i++) {
			if(!humans[i].gameObject.activeSelf)
			{
				humans[i].SetStartPostion(spawnPoint.position);
				humans[i].gameObject.SetActive(true);
				return;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
