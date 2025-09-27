using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;
	public GameObject elementsUnlockedUI;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one GameManager in scene!");
			return;
		}
		instance = this;
	}

	void Start ()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update () {
		if (GameIsOver)
			return;

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame ()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
	}

	public void WinLevel ()
	{
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}

}
