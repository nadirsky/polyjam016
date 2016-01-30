using UnityEngine;
using System.Collections;

public class HumanInstantiator : MonoBehaviour {

	public GameObject humanToInstantiate;
	public Transform spawnPoint;

	public Transform destinationToSet;
	public Transform mainBaseToSet;

	// Use this for initialization
	void Start () {
	
	}

	public void InstantiatePlayer()
	{
		GameObject ob = Instantiate(humanToInstantiate, spawnPoint.position, Quaternion.identity) as GameObject;
		ob.GetComponent<AIBehaviour> ().InitGame (destinationToSet, mainBaseToSet);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
