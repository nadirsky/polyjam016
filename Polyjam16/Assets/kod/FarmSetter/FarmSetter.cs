using UnityEngine;
using System.Collections;

public class FarmSetter : MonoBehaviour {

	public float timeToChange = 5f;


	public float maxChange = 3.0f;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine (ChangeFarmPosition());
	}

	IEnumerator ChangeFarmPosition()
	{
		while (true) {

			yield return new WaitForSeconds(maxChange);

			this.transform.position = Vector3.zero + new Vector3(Random.Range(-maxChange, maxChange), 
			                                                     Random.Range(-maxChange, maxChange));
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
