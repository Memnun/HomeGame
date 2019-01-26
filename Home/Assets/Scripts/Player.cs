using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

	//container class for player data

	public int space; // space id for where the player is -- 1 is start, Globals.tileCount is finish
	public int actionPointsMax;
	public int actionPoints;
	public int inventory[64][2]; //inventory of items, can hold 64 unique items, and infinite count of that item

	//instantiate the playerdata object so it doesnt break things
	public void init () {
		space = 0;
		for (int i = 0; i < 64; i++){
			inventory[i][0] = 0;
			inventory[i][1] = 0;
			actionPointsMax = 0;
			actionPoints = 0;
		}
	}

	//set the player to space 1, set the AP to Globals.startingAP
	public void start () {
		space = 1;
		actionPointsMax = Globals.startingAP;
		actionPoints = Globals.startingAP;
	}

	//start the player turn
	public void startTurn () {
		actionPoints = actionPointsMax;
	}

	//move the player along the board by x distance
	public void move (int distance) {
		if (distance < 0) {
			if (space - distance =< 1) {
				space = 1;
			} else {
				space -= distance;
			}
		} else {
			if (space + distance >= Globals.tileCount) {
				space = Globals.tileCount;
			} else {
				space += distance;
			}
		}
	}

	//move the player to a specific tile
	public void jump (int tile) {
		space = tile;
	}

	//changes the given resource by x quantity. returns true if successful, returns false if failed. failure results from no free inventory slots, or not enough resources to take away.
	public bool gainResource (int itemID, int quantity) {
		for (int i = 0; i < 64; i++) {
			if (inventory[i][0] == itemID) {
				if ((quantity <= 0) && (inventory[i][1]-quantity <= 0)) {
					return false;
				} else {
					inventory[i][1] += quantity;
				}
				return true;
			}
		}
		if (quantity < 0) {
			return false;
		}
		for (int i = 0; i < 64; i++) {
			if (inventory[i][0] == 0) {
				inventory[i][0] = itemID;
				inventory[i][1] = quantity;
				return true;
			}
		}
		return false;
	}

	//change the max AP by delta
	public void changeApMax (int delta) {
		if (actionPointsMax - delta <= 1) {
			actionPointsMax = 1;
		} else {
			actionPointsMax -= delta;
		}
	}

	//spend x AP. fails if you dont have enough AP
	public bool spendAp (int p) {
		if (actionPoints - p < 0) {
			return false;
		} else {
			actionPoints -= p;
			return true;
		}
	}

}
