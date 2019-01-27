using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

	public Player player;
	public Button PlayerMove;
	public Button PlayerDraw;
	public Button PlayerPlay;

	public void moveForward(int distance) {
		if (player.space == 48) {
			player.jump(1);
		} else if (player.space == 82) {
			player.jump(51);
		} else if (player.space == 100) {
			player.jump(85);
		} else {
			player.move(distance);

		}

		GameObject newTile = GameObject.Find("Tile ("+player.space+")");

		transform.position = newTile.transform.position;

		if (newTile.GetComponent<ResourceTileBehavior>() != null) {
			if (newTile.GetComponent<ResourceTileBehavior>().isJumpedOn == 0) {newTile.GetComponent<ResourceTileBehavior>().isJumpedOn = 1;}
			player.gainResource(1,1);
		} else if (newTile.GetComponent<CardTileBehavior>() != null) {
			if (newTile.GetComponent<CardTileBehavior>().isJumpedOn == 0) {newTile.GetComponent<CardTileBehavior>().isJumpedOn = 1;}
			player.gainResource(2,1);
		} else if (newTile.GetComponent<EventTileBehavior>() != null) {
			if (newTile.GetComponent<EventTileBehavior>().isJumpedOn == 0) {newTile.GetComponent<EventTileBehavior>().isJumpedOn = 1;}
			player.changeApMax(1);
		}

		if (player.space == 48 && player.inventory[0].y >= 20) {
			player.jump(66);
		} else if (player.space == 82 && player.inventory[0].y >= 80) {
			player.jump(92);
		} else if (player.space == 100 && player.inventory[0].y >= 16) {
			player.jump(103);
		}
	}

    void Start()
    {
        player.init();
        player.startup();
        PlayerMove.onClick.AddListener(MoveCheck);         //Checks if "Move" has been clicked runs PressCheck with action having a value of 1
        PlayerDraw.onClick.AddListener(DrawCheck);   		//Checks if "Draw" has been clicked runs PressCheck with action having a value of 2
        PlayerPlay.onClick.AddListener(PlayCheck);      //Checks if "Collect" has been clicked runs PressCheck with action having a value of 3
    }


    public void MoveCheck(){
    	if (Globals.currentPlayer == player)
    		{

		 	if (player.spendAp(1))
	    		moveForward(1);
    		}
    	 	
    	 	else 
    	 	{
    			//failed to move
   			}
   		}			

    public void DrawCheck(){
    	if (Globals.currentPlayer == player) {
    	
    		if (player.spendAp(2))
    		{
    			player.gainResource(2,1);
    		}

    		else 
    		{
    				//failed to draw a card
    		}	
    	}
    }

    public void PlayCheck(){
    	if (Globals.currentPlayer == player) 
    	{
    		if (player.gainResource(2,-1))
    		{

    		moveForward(2);

    		} 
    			
    		else 
    		{
    			//had no cards
    		}	
    	}
    }
}
