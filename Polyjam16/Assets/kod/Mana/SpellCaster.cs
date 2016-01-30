using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpellCaster : MonoBehaviour {

	//public Button[] spellBtn;

	public Image CursorImage;

	public Spell[] spell;
	ManaStock manaStock;



	void Start()
	{
		if (CursorImage == null) 
		{
			Debug.LogError ("Nie ma kursora");
			return;
		}

		Spell.mouseCursor = CursorImage;
		Spell.mouseCursor.gameObject.SetActive (false);

		if (spell.Length == 0) {
			Debug.LogError ("Nie ma przypisanych czarów");
			return;
		}

	//	spell = GameObject.FindObjectsOfType<Spell> ();

		manaStock = ManaStock.instance;


	}

	public void ChoseSpell(int number)
	{
		if (ErrorCheck (number))
			return;

		Debug.Log (spell.Length + " a numer " + number);

		Debug.Log (ManaStock.instance.Mana.ToString ());

		if (ManaStock.instance.Mana >= spell[number].cost) 
		{
			if(ManaStock.instance.SpendMana(spell[number].cost))
			{
				spell[number].ActivateSpel();

			}
		}


	}

	bool ErrorCheck(int numb)
	{
		if (spell.Length < numb) {
			Debug.LogError ("Liczba czarow mniejsza od zadanego numeru");
				return true;
		}

			return false;
	}

}
