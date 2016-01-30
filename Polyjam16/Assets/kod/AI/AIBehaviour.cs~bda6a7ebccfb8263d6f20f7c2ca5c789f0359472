using UnityEngine;
using System.Collections;

public class AIBehaviour : MonoBehaviour {

	protected bool goToBase = false;

	public float speed = 3f;

	public Rigidbody2D rig2d;

	public string DestinationTag;
	public string EndTag = "EndGame";

	public Transform destination;
	public Transform mainBase;

	protected Collider2D destinationCol;
	protected Collider2D mainBaseCol;

	protected MeatStock meatMag;

	// Use this for initialization
	void Start () {

		meatMag = MeatStock.instance;
		destinationCol = destination.GetComponent<Collider2D> ();
		mainBaseCol = mainBase.GetComponent<Collider2D> ();
		//rig2d.velocity = (destination.position - this.transform.position).normalized;


	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag (DestinationTag)) 
		{
			//Debug.Log("Dupa");
			goToBase = true;

			//rig2d.velocity = Vector3.zero;

		}

		if (other.CompareTag (DestinationTag)) 
		{
			//Debug.Log("Dupa");
			goToBase = true;
			
			//rig2d.velocity = Vector3.zero;
			
		}

		if (other == mainBaseCol && goToBase == true) 
		{
			goToBase = false;
			meatMag.DoladujMane();
			//rig2d.velocity = Vector3.zero;


		}

		//if (other.CompareTag (DestinationTag))
		//goToBase = true;
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void FixedUpdate()
	{
		if (goToBase) {
			rig2d.velocity = (mainBase.position - this.transform.position).normalized * speed;
		}
		else
			rig2d.velocity = (destination.position - this.transform.position).normalized * speed;
		//if(goToBase)

		//rig2d.velocity = (mainBase.position - this.transform.position).normalized;
		//else
			//rig2d.velocity = (destination.position - this.transform.position).normalized;

	}
}
