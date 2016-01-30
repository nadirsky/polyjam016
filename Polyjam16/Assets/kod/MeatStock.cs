using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeatStock : MonoBehaviour {


	float firstPlayerTime = 1f;
	float secondPlayerTime = 1f;
	float thirdPlayerTime = 1f;

	float firstTime = 0;
	float secondTime = 0;
	float thirdTime = 0;

	public HumanInstantiator[] playerInstantiator;

	public float timeToGenerate = 1f;
	public float timerek = 0;
	public int meatGenerateAmount = 2;

	public static MeatStock instance = null;
	public Text manaText;

	public int meatAdd = 1;
	public int productionMeatCost = 3;
	public int meatPoints = 9;

	public int secondPlayerMeat = 9;
	public int thirdPlayerMeat = 9;



	void Awake () {
		if (playerInstantiator.Length == 0 || playerInstantiator.Length > 3) 
		{
			Debug.LogError ("Dupa");
			return;
		}


		if (instance == null) 
		{
			instance = this;
			return;
		}	
		Destroy (this);
	}

	void CreateFirstPlayerHuman()
	{

		if(meatPoints >= productionMeatCost)
		{
			if(playerInstantiator [0].InstantiatePlayer ())

			
			{
				meatPoints -= productionMeatCost;

				manaText.text = meatPoints.ToString ();
			}
		}



	}

	void CreateSecondPlayerHuman()
	{
		if(secondPlayerMeat >= productionMeatCost)
		{
			if(playerInstantiator [1].InstantiatePlayer ())
			
			{

				secondPlayerMeat -= productionMeatCost;
			
			}
			//manaText.text = meatPoints.ToString ();
		}
	}

	void CreateThirdPlayerHuman()
	{
		if(thirdPlayerMeat >= productionMeatCost)
		{
			if(playerInstantiator [2].InstantiatePlayer ())

			{

				thirdPlayerMeat -= productionMeatCost;

			}
			//manaText.text = meatPoints.ToString ();
		}
	}


	public virtual void AddSomeMeat()
	{
		meatPoints += meatAdd;

		manaText.text = meatPoints.ToString ();
	}

	public void AddSomeMeatToSecondPlayer()
	{
		secondPlayerMeat += meatAdd;
	}

	public void AddSomeMeatToThirdPlayer()
	{
		thirdPlayerMeat += meatAdd;
	}

	void Update()
	{

			timerek += Time.deltaTime;
			
			while(timerek >= timeToGenerate)
			{
				timerek = timerek - timeToGenerate;
				
				//ManaStock.instance.GenerateMana(aiBehaviourList.Count);

			//meatPoints += meatGenerateAmount;
			//secondPlayerMeat += meatGenerateAmount;
				


			}
	}

	void FixedUpdate()
	{
		firstTime += Time.deltaTime;
		secondTime += Time.deltaTime;
		thirdTime += Time.deltaTime;



		if (firstTime >= firstPlayerTime) 
		{
			CreateFirstPlayerHuman ();

			firstTime = firstTime - firstPlayerTime;
		}
		if(secondTime >= secondPlayerTime)
		{
			CreateSecondPlayerHuman ();
			secondTime = secondTime - secondPlayerTime;
		}
		if(thirdTime >= thirdPlayerTime && playerInstantiator.Length > 2)
		{
			CreateThirdPlayerHuman ();
			thirdTime = thirdTime - thirdPlayerTime;
		}

	}
}
