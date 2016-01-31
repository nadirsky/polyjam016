using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChoser : MonoBehaviour {

	public Button[] buttons;
	public bool resetSettings = false;

	// Use this for initialization
	void Start () {

		buttons = this.transform.GetComponentsInChildren<Button> ();


		Debug.Log ("Robie");
		//InitPlayerPrefs ();
		//DisableAllButtons ();
	//	SetButtonView ();
	
	}

	void InitPlayerPrefs()
	{
		if(!PlayerPrefs.HasKey("level0") || resetSettings)
		 {
			for(int i =0; i<buttons.Length; i++)
			{
				if(i == 0)
				{
					PlayerPrefs.SetInt("level"+i, 1);
				}
				else
				{
					PlayerPrefs.SetInt("level"+i, 0);

				}
			}

			//PlayerPrefs.SetInt(
		}
	}

	void DisableAllButtons()
	{
		for (int i =0; i<buttons.Length; i++) 
		{
			buttons[i].interactable = false;
		}
	}

	void SetButtonView()
	{
		for (int i =0; i<buttons.Length; i++) 
		{
			if(PlayerPrefs.GetInt("level"+i) == 1)
			{
				buttons[i].interactable = true;
				return;
			}

			if(PlayerPrefs.GetInt("level"+i) == 0)
			{
				return;
			}

			if(PlayerPrefs.GetInt("level"+i) == 2)
			{
				buttons[i].interactable = true;
			}
		}
	}

   public void GoToMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void LoadScene(int number)
    {
        SceneManager.LoadScene(number);

    }

	// Update is called once per frame
	void Update () {
	
	}
}
