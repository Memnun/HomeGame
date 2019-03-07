using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : Singleton<Globals> {
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	/*
	general notes can go here

	fox -> rabbit -> squirrel -> hedgehog
	28-18-10
	
	on turn start:
	move to selected player
	open controls to player
	player picks a command
	if the player doesnt have enough ap, the command greys out and is unselectable
	when the player selects "End Turn," their AP resets to the ring quantity and the next turn begins

	*/
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public int tileCount = 57;
	public int startingAP = 2;
	public int players;
	public int currentPlayer;
	public Player[] playerList;
	public CardHandler cardhandler;


	void Start () {
		//
	}

	void Update () {
		//
	}
	

}
