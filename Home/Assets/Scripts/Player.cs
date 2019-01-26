using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

	//container class for player data

	public int space; // space id for where the player is -- 1 is start, 100 is finish
	public int inventory[64][2]; //inventory of items, can hold 64 unique items, and infinite count of that item

	//instantiate the playerdata object so it doesnt break things
	public void init () {
		space = 0;
		for (int i = 0; i < 64; i++){
			inventory[i][0] = 0;
			inventory[i][1] = 0;
		}
	}

	//set the player to space 1
	public void start () {
		space = 1;
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
			if (space + distance >= 100) {
				space = 100;
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

}
