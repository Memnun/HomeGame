using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//container class for player data

	public int space; // space id for where the player is -- 1 is start, Globals.tileCount is finish
	public int actionPointsMax;
	public int actionPoints;
	public Vector2[] inventory; //inventory of items, can hold 64 unique items, and infinite count of that item
	public bool targetable;
	public int currentTileType;

	public GameObject currentTile;
	public float animSpeed;
	public Vector3 currentPos;
	public float animTime;

	//instantiate the playerdata object so it doesnt break things
	public void init () {
		space = 0;
		inventory = new Vector2[64];
		for (int i = 0; i < 64; i++){
			inventory[i].x = 0;
			inventory[i].y = 0;
		}
		actionPointsMax = 0;
		actionPoints = 0;
		currentTileType = 0;
		targetable = true;
		animSpeed = 2f;
	}

	//set the player to space 1, set the AP to Globals.startingAP
	public void startup () {
		space = 1;
		inventory[0].x = 1;
		actionPointsMax = Globals.startingAP;
		actionPoints = Globals.startingAP;
	}

	//start the player turn
	public void startTurn () {
		actionPoints = actionPointsMax;
		targetable = true;
	}

	//move the player along the board by x distance
	public void move (int distance) {
		if (distance < 0) {
			if (space - distance <= 1) {
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
			if (inventory[i].x == itemID) {
				if ((quantity <= 0) && (inventory[i].y-quantity <= 0)) {
					return false;
				} else {
					inventory[i].y += quantity;
				}
				return true;
			}
		}
		if (quantity < 0) {
			return false;
		}
		for (int i = 0; i < 64; i++) {
			if (inventory[i].x == 0) {
				inventory[i].x = itemID;
				inventory[i].y = quantity;
				return true;
			}
		}
		return false;
	}

	//change the max AP by delta
	public void changeApMax (int delta) {
		if (actionPointsMax + delta <= 1) {
			actionPointsMax = 1;
		} else {
			actionPointsMax += delta;
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

	void Update () {
		transform.position = Vector3.Lerp(currentPos, currentTile.transform.position, (Time.time-animTime)*animSpeed);
	}

}
