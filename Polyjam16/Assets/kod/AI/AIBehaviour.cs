using UnityEngine;
using System.Collections;

public class AIBehaviour : MonoBehaviour {

	public bool ritualState = false;
	protected bool goToBase = false;

	public float speed = 3f;

	public Rigidbody2D rig2d;

	public string DestinationTag = "Finish";
	public string EndTag = "EndGame";

	public Transform destination;
	public Transform mainBase;

	protected Collider2D destinationCol;
	protected Collider2D mainBaseCol;

	protected MeatStock meatMag;

	public void InitGame(Transform dest, Transform mainBase2)
	{
		destination = dest;
		//Debug.Log (dest.name);

		mainBase = mainBase2;
		//Debug.Log (mainBase.name);

		SetColliders ();
	}
	
	void Start () {


		SetColliders ();

	}

	public void BreakRitual()
	{
		ritualState = false;
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

		destinationCol = destination.GetComponent<Collider2D> ();
		mainBaseCol = mainBase.GetComponent<Collider2D> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag (DestinationTag)) 
		{
			goToBase = true;
		}

		if (other == mainBaseCol && goToBase == true) 
		{
			goToBase = false;
			meatMag.AddSomeMeat();

			if(RitualScript.instance.GetPlayerRitual)
			{
				RitualScript.instance.AdAibehaviourToList(this);
				ritualState = true;
			}

		}

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
			rig2d.velocity = (mainBase.position - this.transform.position).normalized * speed;
		}
		else
			rig2d.velocity = (destination.position - this.transform.position).normalized * speed;
	}
}
