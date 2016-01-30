using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManaStock : MonoBehaviour {

	static public ManaStock instance = null;
	public Text manaText;
	int mana = 200;

	public int Mana
	{
		get
		{
			return mana;
		}
	}

	public bool SpendMana(int manaCost)
	{
		if (manaCost <= mana) {
			mana -= manaCost;
			manaText.text = mana.ToString ();
			return true;
		}

		return false;
	}

	// Use this for initialization
	void Start () {
	if (instance != null) {
			Destroy (this);
			return;
		}

		instance = this;

		manaText.text = mana.ToString ();
		//Debug.Log (ManaStock.instance.Mana.ToString ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenerateMana(int amount)
	{
		mana += amount;
		manaText.text = mana.ToString ();
	}


}
