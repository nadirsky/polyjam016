using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceCreator : MonoBehaviour {

	const float MAPSIZE = 4.0f;
	const int WAITTIME = 10;
	public int timer = 0;
	const int MAXRESOURCES = 20;
	public GameObject pref;
	public static List<GameObject> resources = new List<GameObject>();

	public static Vector3 CreateResPos(){
		return new Vector3 (Random.Range (-MAPSIZE, MAPSIZE), Random.Range (-MAPSIZE, MAPSIZE), 0);
	}

	void SpawnResource(){
		Vector3 pos = CreateResPos ();
		GameObject g = (GameObject) Instantiate (pref, pos, Quaternion.identity);
		resources.Add (g);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		timer++;
		if (timer % WAITTIME == 0 && resources.Count < MAXRESOURCES) {
			SpawnResource ();
			timer = 0;
		}
	}
}
