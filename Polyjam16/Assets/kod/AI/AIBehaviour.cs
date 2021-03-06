﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIBehaviour : MonoBehaviour {

	public bool ritualState = false;
	protected bool goToBase = false;
	public int playerNo;

	public float helpForSpeed;
	public float slowFastTime = 5f;
	public float slowFastTimeProgress = 0;
	protected bool slowFast = false;

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
		List<GameObject> resources = ResourceCreator.instance.resources;
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
			other.gameObject.transform.position = ResourceCreator.instance.CreateResPos2 ();
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

//	public void MakeFaster(float f){
//
//	}
//
//	public void SlowDown(float f){
//
//	}
//
//
//	void FixedUpdate()
//	{
//		if (ritualState) 
//		{
//			rig2d.velocity = Vector2.zero;
//			return;
//		}
//		if (goToBase) 
//		{
//			rig2d.velocity = (mainBase.transform.position - this.transform.position).normalized * speed;
//		}
//		else
//			rig2d.velocity = (currentDestination.transform.position - this.transform.position).normalized * speed;
//	}

	
	public void SlowDown(float amount)
	{
		helpForSpeed = speed * amount;
		slowFast = true;
	}
	
	public void MakeFaster(float amount)
	{
		helpForSpeed = speed / amount;
		slowFast = true;
	}
	
	void FixedUpdate()
	{
		
		if (slowFast) 
		{
			slowFastTimeProgress+=Time.deltaTime;
			
			if(slowFastTimeProgress >= slowFastTime)
			{
				slowFast = false;
				slowFastTimeProgress = 0;
			}
		}
		
		if (ritualState) 
		{
			rig2d.velocity = Vector2.zero;
			return;
		}
		if (goToBase) {
			
			if(slowFast)
			{
				rig2d.velocity = (mainBase.transform.position - this.transform.position).normalized * helpForSpeed;
				return;
			}
			//this.transform.Translate((mainBase.transform.position - this.transform.position).normalized * speed);
			rig2d.velocity = (mainBase.transform.position - this.transform.position).normalized * speed;
			//Debug.Log ("Ruszam do bazy");
			//rig2d.AddForce((mainBase.position - this.transform.position).normalized * speed);
		} else {
			
			if(slowFast)
			{
				rig2d.velocity = (currentDestination.transform.position - this.transform.position).normalized * helpForSpeed;
				return;
			}
			//this.transform.Translate((destination.transform.position - this.transform.position).normalized * speed);
			rig2d.velocity = (currentDestination.transform.position - this.transform.position).normalized * speed;
			//Debug.Log ("Ruszam do czegos");
		}
		
		//Debug.Log (destination.transform.position + " cos");
		//rig2d.AddForce((destination.position - this.transform.position).normalized * speed);
	}
}
