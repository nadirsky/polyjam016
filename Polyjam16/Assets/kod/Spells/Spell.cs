using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Spell : MonoBehaviour {

	public string playerTagToCompare = "Player";
	public string compTagToCompare = "GameController";

	public static Image mouseCursor;
	public Sprite cursorSprite;
	public int cost = 10;
	public ParticleSystem particleSystem;

	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	protected bool spellActive = false;

	Vector3 helpVec;

	public virtual void ActivateSpel()
	{
		//Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		Cursor.visible = false;
		spellActive = true;
		mouseCursor.sprite = cursorSprite;
		mouseCursor.gameObject.SetActive (true);

	}

	public virtual void RunSpell()
	{
		//Cursor.SetCursor(null, hotSpot, cursorMode);
		helpVec = Input.mousePosition + new Vector3 (0f, 0f, 10f); 

		helpVec = Camera.main.ScreenToWorldPoint (helpVec);
		helpVec.z = 0;


		//Debug.Log (helpVec);
		particleSystem.transform.position = helpVec;
		particleSystem.Play();

		Cursor.visible = true;
		spellActive = false;
		mouseCursor.gameObject.SetActive (false);
	}

	protected void Update()
	{
		if (spellActive) {
			if(Input.GetButtonDown("Fire1"))
			{
				RunSpell();
			}

			mouseCursor.transform.position = Input.mousePosition;

		}

	}

//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}
