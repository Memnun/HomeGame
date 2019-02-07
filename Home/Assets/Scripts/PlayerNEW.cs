using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int space; //current space's numeric id
	public int currentTileType; //type for the current tile;
	public int currentSeason; //which ring you're on - 1 for spring, 2 for summer, 3 for fall
	public int previousSeason; //the previous game frame's season, for audio queues

	
	public int actionPoints; //current action points
	public int[] cards; //cards in hand
	public int berries; //current berry count

	//object references used for animations
	public GameObject currentTile;
	public float animSpeed;
	public Vector3 currentPos;
	public float animTime;

	public Globals g;

	public void init () {
		cards = new int[3];
	}

}