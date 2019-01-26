using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

	public Player player;

	private void moveForward(int distance) {
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
    }

    void Update () {
    	//this script is only useful for the given player on their turn
    	if (Globals.currentPlayer == player) {
    		if (Input.GetKeyDown(KeyCode.M)) {
    			if (player.spendAp(1)) {
	    			moveForward(1);
    			} else {
    				//failed to move
    			}
    		}
    		if (Input.GetKeyDown(KeyCode.D)) {
    			if (player.spendAp(2)) {
    				player.gainResource(2,1);
    			} else {
    				//failed to draw a card
    			}
    		}
    		if (Input.GetKeyDown(KeyCode.P)) {
    			if (player.gainResource(2,-1)) {
    				moveForward(2);
    			} else {
    				//had no cards
    			}
    		}
    	}

    }
}
