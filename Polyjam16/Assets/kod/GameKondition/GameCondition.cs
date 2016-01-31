using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameCondition : MonoBehaviour {

	public int levelToUnlock;
    public int nextLevel;
    bool endGame = false;

    public float waitingTime = 5f;
    public float alarmScaler = 0.25f;
    bool scremNow = false;

    float timeChecker = 0;
    float timeToCheck = 2;

    float timeOtherPlayersChecker = 0;
    float timeOtherPlayerToCheck = 2.21f;

	public Button retryBtn;
	public Button toMainMenu;


	public Text victoryText;
	public GameObject victoryPanel;
	public Text humanCountText;
	public int maxPopulation = 40;
	public int victoryPopulation = 30;

    AudioSource audioSource;

	//public string playerTag = "Player";
	//
	//public static int  humansCount;

	 HumanInstantiator[] humansInstantiator;

    List<HumanInstantiator> botHumanInstantiator = new List<HumanInstantiator>();

	public HumanInstantiator playerHumansInstantiator;

    MeatStock meatStock;

    void TurnOnScreemer()
    {
        scremNow = true;

    }

	void Awake()
	{
        Invoke("TurnOnScreemer", waitingTime);

        audioSource = this.GetComponent<AudioSource>();

        meatStock = GameObject.FindObjectOfType<MeatStock>();

        victoryText.text = "";
		retryBtn.onClick.AddListener (RetryBtnAction);
		toMainMenu.onClick.AddListener (ContinoueAction);


		//humanCountText = this.GetComponent<Text> ();
		victoryPanel.SetActive (false);
		UpdatePlayer (0);
		playerHumansInstantiator.gameCondition = this;
		humansInstantiator = GameObject.FindObjectsOfType<HumanInstantiator> ();


        //botHumanInstantiator = new HumanInstantiator[humansInstantiator.Length];
		for (int i = 0; i< humansInstantiator.Length; i++) 
		{
			humansInstantiator[i].maxHumans = maxPopulation;

            if (humansInstantiator[i] != playerHumansInstantiator)
            {
                botHumanInstantiator.Add(humansInstantiator[i]);
            }

//			if(humansInstantiator[i].CompareTag(humansInstantiator))
//			{
//				playerHumansInstantiator = humansInstantiator[i];
//				playerHumansInstantiator.gameCondition = this;
//
//				Debug.Log("Ustawiam klase");
//			}

		}
	}

	void ContinoueAction()
	{

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
		//Application.LoadLevel (0);
	}

	void RetryBtnAction()
	{

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);

        //SceneManager.LoadScene()
		//Application.LoadLevel (Application.loadedLevel);
	}

    void AudioSoundBeeper(int players)
    {
        if (scremNow)
        {
            if (players <= alarmScaler * maxPopulation)
            {
                if(!audioSource.isPlaying)
                audioSource.Play();
                // audioSource.Play();
                //audioSource.loop = true;

            }
            else
            {
                audioSource.loop = false;
            }
        }

    }

	public void UpdatePlayer(int players)
    {
        //Debug.Log ("Updatuje" + players);
        timeToCheck = 0;
		humanCountText.text = players + "/" + victoryPopulation;

		if (players > victoryPopulation) 
		{
            WinMatch();
			//Debug.Log("Victory");
		}

        AudioSoundBeeper(players);


        if (players == 0)
        {
            if (meatStock.EmptyStock())
            {
                Time.timeScale = 0;
                victoryPanel.SetActive(true);
                victoryText.text = "You lose";
                // PlayerPrefs.SetInt("level" + levelToUnlock, 2);

                endGame = true;
            }

        }

	}


	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
    void WinMatch()
    {
        Time.timeScale = 0;
        victoryPanel.SetActive(true);
        victoryText.text = "Victory";
        PlayerPrefs.SetInt("level" + levelToUnlock, 2);

        endGame = true;

        if (nextLevel < 1000)
        {
            PlayerPrefs.SetInt("level" + nextLevel, 1);
        }

        //Debug.Log("WYGRYWAM MECZ");
    }

	void Update () {

        if (!endGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!victoryPanel.activeSelf)
                {
                    victoryPanel.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    victoryPanel.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }

        timeChecker += Time.deltaTime;
        if (timeChecker >= timeToCheck)
        {
            timeChecker = 0;
            playerHumansInstantiator.ExecuteCount();
        }

        timeOtherPlayersChecker += Time.deltaTime;
        if(timeOtherPlayersChecker >= timeOtherPlayerToCheck)
        {
            timeOtherPlayersChecker = 0;

           // bool win = true;

            for (int i = 0; i < botHumanInstantiator.Count; i++)
            {
                botHumanInstantiator[i].ExecuteCount();
                if(botHumanInstantiator[i].CurrentActiveHuman != 0)
                {
                    //win = false;
                    return ;
                }
            }
            WinMatch();


        }



       
	
	}
}
