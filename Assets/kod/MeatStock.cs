using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeatStock : MonoBehaviour {

	public static MeatStock instance = null;

	public Text manaText;


	public int meatAdd = 1;
	public int meatPoints;

	public int secondPlayerMeat;

	// Use this for initialization
	void Awake () {
		if (instance == null) 
		{
			instance = this;
			return;
		}
	
		Destroy (this);
	}


	public virtual void DoladujMane()
	{
		meatPoints += meatAdd;
		manaText.text = meatPoints.ToString ();
	}

	public void DoladujManeDrugiemu()
	{
		secondPlayerMeat += meatAdd;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
