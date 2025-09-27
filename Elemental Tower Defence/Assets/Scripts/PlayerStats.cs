using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 20;

	public static bool fireUnlocked;
	public static bool waterUnlocked;
	public static bool earthUnlocked;
	public static bool windUnlocked;

	public static bool metalUnlocked;
	public static bool lightningUnlocked;
	public static bool woodUnlocked;
	public static bool iceUnlocked;

	public static int Rounds;

	void Start ()
	{
		// the values are set inside the inspector
		Money = startMoney;
		Lives = startLives;
		Rounds = 0;
	}

}
