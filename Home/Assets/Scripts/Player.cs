using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int space; //current space's numeric id
	public int currentTileType; //type for the current tile; 0 for empty, 1 for berry, 2 for card, 3 for event, 4 for gate
	public int currentSeason; //which ring you're on - 1 for spring, 2 for summer, 3 for fall
	public int previousSeason; //the previous game frame's season, for audio queues

	public int lookingAt;
	public bool collectible;
	
	public int actionPoints; //current action points
	public int[] cards; //cards in hand
	public int berries; //current berry count
	public int currentAP; //current AP

	//object references used for animations
	public GameObject currentTile;
	public float animSpeed;
	public Vector3 currentPos;
	public float animTime;

	public Globals g;

	public void init () {
		cards = new int[3];
		space = 1;
	}

	public bool moveAlongRing (int distance) {
		//
		if (currentSeason == 1) {
			space = (space % 28) + 1;
			return true;
		} else if (currentSeason == 2) {
			space = ((space-28) % 18) + 29;
			return true;
		} else if (currentSeason == 3) {
			space = ((space-46) % 10) + 47;
			return true;
		}
		return false;
	}

	public bool moveToNextSeason () {
		if (currentTileType == 4 && berries >= 10) {
			space = 29;
			berries -= 10;
			return true;
		} else if (currentTileType == 4 && berries >= 10) {
			space = 47;
			berries -= 10;
			return true;
		} else if (currentTileType == 4 && berries >= 10) {
			space = 57;
			berries -= 10;
			return true;
		}
		return false;
	}

	public bool pickUpCard () {
		//draw then discard
		// if (collectibe && currentTileType == 2 && cards[3] == 0) {
		// 	if (cards[0] == 0) {
		// 		cards[0] = Random.Range(1,11);
		// 	} else if (cards[1] == 0) {
		// 		cards[1] = Random.Range(1,11);
		// 	} else if (cards[2] == 0) {
		// 		cards[2] = Random.Range(1,11);
		// 	} else {
		// 		cards[3] = Random.Range(1,11);
		// 		discardACard();
		// 	}
		// 	collectible = false;
		// 	return true;
		// }

		//discard then draw
		// if (collectible && currentTileType == 2 && cards[2] == 0) {
		// 	if (cards[0] == 0) {
		// 		cards[0] = Random.Range(1,11);
		// 	} else if (cards[1] == 0) {
		// 		cards[1] = Random.Range(1,11);
		// 	} else {
		// 		cards[2] = Random.Range(1,11);
		// 	}
		// 	collectible = false;
		// 	return true;
		// }


		return false;
	}

	public bool pickUpBerry () {
		if (collectible && currentTileType == 1) {
			berries++;
			collectible = false;
			return true;
		}
		return false;
	}

	public bool discardACard (int position) {
		cards[position] = 0;
		if (position == 0) {
			cards[0]=cards[1];
			cards[1]=cards[2];
			cards[2]=cards[3];
			cards[3]=0;
		} else if (position == 1) {
			cards[1]=cards[2];
			cards[2]=cards[3];
			cards[3]=0;
		} else if (position == 2) {
			cards[2]=cards[3];
			cards[3]=0;
		} else {
			return true;
		}
		return false;
	}

	public bool playACard (int position, GameObject target) {
		if (card[position] != 0) {
		Globals.Instance.cardhandler.PlayCard(cards[position], this, target);
		return true;
		}
		return false;
	}

	public bool lookAtOwnCards () {
		if (lookingAt == 0) {
			lookingAt = 1;
			return true;
		}
		return false;
	}

	public bool lookAtOpponentCards () {
		if (lookingAt == 0) {
			lookingAt = 2;
			return true;
		}
		return false;
	}

	public bool returnToBoard () {
		if (lookingAt != 0) {
			lookingAt = 0;
			return true;
		}
		return false;
	}

	public bool endTurn () {
		switch (currentSeason) {
			case 1:
				currentAP = 6;
				return true;
				break;
			case 2:
				currentAP = 4;
				return true;
				break;
			case 3:
				currentAP = 3;
				return true;
				break;
			default:
				return false;
		}
		return false;
	}

	/*
	activate an event
	*/

}