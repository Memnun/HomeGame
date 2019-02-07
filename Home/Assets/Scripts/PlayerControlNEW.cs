using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

	public Player player;
	public Button PlayerMove;
	public Button PlayerCollect;
	public Button PlayerCheck;
	public Button PlayerEnd;

	//public GameObject MainCamera;
    //public GameObject Player1POS, Player2POS, Player3POS, Player4POS;

	public void moveForward(int distance) {
		if (player.space == 28) {
			player.jump(1);
		} else if (player.space == 46) {
			player.jump(29);
		} else if (player.space == 56) {
			player.jump(47);
		} else {
			player.move(distance);

		}

		CameraCont cameracont = GameObject.Find("GameBoard").GetComponent<CameraCont>();
		GameObject.Find("FMOD Audio").GetComponent<GameAudio>().walkInstance();
		GameObject newTile = GameObject.Find("Tile ("+player.space+")");

		cameracont.lerpTimer = Time.time;
		cameracont.startingPos = cameracont.MainCamera.transform.position;
		player.currentPos = transform.position;
		player.currentTile = newTile;
		player.animTime = Time.time;

		if (newTile.GetComponent<ResourceTileBehavior>() != null) {
			if (newTile.GetComponent<ResourceTileBehavior>().isJumpedOn == 0) {newTile.GetComponent<ResourceTileBehavior>().isJumpedOn = 1;}
			player.currentTileType = 1;
			GameObject.Find("FMOD Audio").GetComponent<GameAudio>().getResource();
		} else if (newTile.GetComponent<CardTileBehavior>() != null) {
			if (newTile.GetComponent<CardTileBehavior>().isJumpedOn == 0) {newTile.GetComponent<CardTileBehavior>().isJumpedOn = 1;}
			player.currentTileType = 2;
		} else if (newTile.GetComponent<EventTileBehavior>() != null) {
			if (newTile.GetComponent<EventTileBehavior>().isJumpedOn == 0) {newTile.GetComponent<EventTileBehavior>().isJumpedOn = 1;}
			player.currentTileType = 3;
			Globals.cardhandler.PlayCard(Random.Range(2,10), player.gameObject, player.gameObject.name == "Player1" ? GameObject.Find("Player2"):GameObject.Find("Player1"));
		}
		if (newTile.GetComponent<PassageHandler>() != null) {newTile.GetComponent<PassageHandler>().isJumpedOn = 1;}

		if (player.space == 28 && player.inventory[0].y >= 10) {
			player.jump(29);
		} else if (player.space == 35 && player.inventory[0].y >= 20) {
			player.jump(47);
		} else if (player.space == 48 && player.inventory[0].y >= 30) {
			player.jump(57);
		}
	}

	// draw a random card and add it to the inventory
	public void cardDraw() {
		//
	}

    void Start() {
    	//
    }


    public void MoveCheck() {
    	if (Globals.currentPlayer == player) {
		 	if (player.spendAp(1))
	    		moveForward(1);
    	} else {
    		//failed to move
   		}
   	}

    public void CollectCheck(){
    	if (Globals.currentPlayer == player) {
    		if (player.currentTileType == 1 && player.spendAp(1)) {
    			player.gainResource(1,1);
    		}
    		if (player.currentTileType == 2 && player.spendAp(2))
    		{
    			cardDraw();
    		}

    		else 
    		{
    				//failed to draw a card
    		}	
    	}
    }

    public void EndCheck(){
    if (Globals.currentPlayer == player) 
    	{
    		player.actionPoints = 0;
    	}
    }

    public void PlayCheck(){
    	if (Globals.currentPlayer == player) 
    	{
    		//card play will be reimplemented once the inventory is shown to the player
    		/*if (player.gainResource(2,-1))
    		{

    		moveForward(2);

    		} 
    			
    		else 
    		{
    			//had no cards
    		}*/
    	}
    }     
}
