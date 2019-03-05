using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/*
	general notes can go here

	fox -> rabbit -> squirrel -> hedgehog
	28-18-10
	*/
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public static int tileCount = 57;
	public static int startingAP = 2;
	public static int players;
	public static int currentPlayer;
	public static Player[] playerList;
	public static CardHandler cardhandler;


	void Start () {
		cardhandler = new CardHandler();
		switch (players) {
			case 2:
				GameObject.Find("Player3").SetActive(false);
				GameObject.Find("Player4").SetActive(false);
				break;
			case 3:
				GameObject.Find("Player4").SetActive(false);
				break;
			default:
				break;

		}
		Globals.currentPlayer = Globals.playerList[0];
		Globals.currentPlayerNumber = 1;
	}

	void Update () {
		if (Globals.currentPlayer.actionPoints == 0) {
			if (Globals.currentPlayerNumber == Globals.players) {
				Globals.currentPlayer = Globals.playerList[0];
				Globals.currentPlayerNumber = 1;
			} else {
				Globals.currentPlayer = Globals.playerList[Globals.currentPlayerNumber];
				Globals.currentPlayerNumber++;
			}
			Globals.currentPlayer.startTurn();
			// GetComponent<CameraCont>().currentPos
		}
	}

}
