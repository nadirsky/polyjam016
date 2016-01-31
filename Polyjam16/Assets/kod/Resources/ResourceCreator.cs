using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceCreator : MonoBehaviour {



    public static ResourceCreator instance;

    const float MAPSIZE = 4.0f;
    const float MAPSIZEHeight = 3.0f;
    const int WAITTIME = 10;
	public int timer = 0;
	const int MAXRESOURCES = 20;
	public GameObject pref;
	public List<GameObject> resources = new List<GameObject>();

    HumanInstantiator[] humInstant;
    public float distanceFromCastle = 1f;



   // public static Vector3 CreateResPos()
   // {
    //    return new Vector3(Random.Range(-MAPSIZE, MAPSIZE), Random.Range(-MAPSIZE, MAPSIZE), 0);
    //}

    public  Vector3 CreateResPos2()
    {
        Vector3 vec;

        do
        {
            vec = new Vector3(Random.Range(-MAPSIZE, MAPSIZE), Random.Range(-MAPSIZEHeight, MAPSIZEHeight+1), 0); ;
        }
        while (DistanceCheck(vec));

        return vec;

        
    }



    bool DistanceCheck(Vector3 dist)
    {
        for (int i = 0; i < humInstant.Length; i++)
        {
            if(Vector3.Distance(humInstant[i].transform.position, dist ) < distanceFromCastle)
            {

                return true;
            }

        }

        return false;

    }

	void SpawnResource(){
        //Vector3 pos;

        

        
		GameObject g = (GameObject) Instantiate (pref, CreateResPos2(), Quaternion.identity);
		resources.Add (g);
	}

	// Use this for initialization
	void Start () {

        if(instance != null)
        {
            Destroy(this);
            return;

        }

        instance = this;

        humInstant = GameObject.FindObjectsOfType<HumanInstantiator>();

        


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
