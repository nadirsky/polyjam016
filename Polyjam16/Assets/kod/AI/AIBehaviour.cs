using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIBehaviour : MonoBehaviour {

	public bool ritualState = false;
	protected bool goToBase = false;

	public float speed = 3f;

	public Rigidbody2D rig2d;

	public string DestinationTag = "Finish";
	public string EndTag = "EndGame";

	public GameObject destination;
	public GameObject currentDestination;
	public GameObject mainBase;

	protected Collider2D destinationCol;
	protected Collider2D mainBaseCol;

	protected MeatStock meatMag;

	public void InitGame(GameObject dest, GameObject mainBase2)
	{
		destination = dest;
		//Debug.Log (dest.name);

		mainBase = mainBase2;
		SetColliders ();
	}
	
	void Start () {
		SetColliders ();
	}

	public void BreakRitual()
	{
		ritualState = false;
		SetDestinationCollider();
	}

	public void SetDestinationCollider(){
		List<GameObject> resources = ResourceCreator.resources;
		if (resources.Count == 0) {
			currentDestination = destination;
		} else {
			int i = Random.Range (0, resources.Count - 1);
			currentDestination = resources [i];
		}
		destinationCol = destination.transform.GetComponent<Collider2D> ();
	}

	public void SetStartPostion(Vector3 posit)
	{
		this.transform.position = posit;
		ritualState = false;
		goToBase = false;
	}

	void SetColliders()
	{
		meatMag = MeatStock.instance;

		SetDestinationCollider(); //destinationCol = destination.GetComponent<Collider2D> ();
		mainBaseCol = mainBase.GetComponent<Collider2D> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Resource") 
		{
			goToBase = true;
			other.gameObject.transform.position = ResourceCreator.CreateResPos ();
		}
		if (other.tag == "Finish") 
		{
			goToBase = true;
		}

		if (other == mainBaseCol && goToBase == true) 
		{
			goToBase = false;
			meatMag.AddSomeMeat();
			SetDestinationCollider();

			if(RitualScript.instance.GetPlayerRitual)
			{
				RitualScript.instance.AdAibehaviourToList(this);
				ritualState = true;
			}

		}

	}

	public void MakeFaster(float f){
	}

	public void SlowDown(float f){
	}


	void FixedUpdate()
	{
		if (ritualState) 
		{
			rig2d.velocity = Vector2.zero;
			return;
		}
		if (goToBase) 
		{
			rig2d.velocity = (mainBase.transform.position - this.transform.position).normalized * speed;
		}
		else
			rig2d.velocity = (currentDestination.transform.position - this.transform.position).normalized * speed;
	}
}
