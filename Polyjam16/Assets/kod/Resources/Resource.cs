using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	public void Reset(){
		this.transform.position = ResourceCreator.CreateResPos ();
	}

	/*void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") 
		{
			this.transform.position = ResourceCreator.CreateResPos ();
		}
	}*/
}
