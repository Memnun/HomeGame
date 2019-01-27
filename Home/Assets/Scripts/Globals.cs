using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /*
    general notes can go here

    fox -> rabbit -> squirrel -> hedgehog
    28-18-10

    materials go in the Resources folder
    tile 48: jump to 66 if you have 20, otherwise wrap to 1
    tile 82: jump to 92 if you have 80, otherwise wrap to 51
    tile 100: jump to 103 if you have 160, otherwise wrap to 85
    unimplimented itemids:
	10-trap a space(? how to select a specific tile)
	11-move another player anywhere(? how to select a specific tile)
	12-counter card(? too many edge cases)
	13-shuffle(? hard to implement)
	19-reverse turn order(? modifying things low level)
    */
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public static int tileCount = 103;
    public static int startingAP = 2;
    public static int players;
    public static Player currentPlayer;
    public static int currentPlayerNumber;
    public static Player[] playerList = new Player[4];


    void Start () {
    	Globals.players = 4;
    	switch (players) {
    		case 2:
	    		Globals.playerList[0] = GameObject.Find("Player1").GetComponent<Player>();
	    		Globals.playerList[1] = GameObject.Find("Player2").GetComponent<Player>();
	    		break;
    		case 3:
    			Globals.playerList[0] = GameObject.Find("Player1").GetComponent<Player>();
	    		Globals.playerList[1] = GameObject.Find("Player2").GetComponent<Player>();
	    		Globals.playerList[2] = GameObject.Find("Player3").GetComponent<Player>();
	    		break;
    		case 4:
    			Globals.playerList[0] = GameObject.Find("Player1").GetComponent<Player>();
	    		Globals.playerList[1] = GameObject.Find("Player2").GetComponent<Player>();
	    		Globals.playerList[2] = GameObject.Find("Player3").GetComponent<Player>();
	    		Globals.playerList[3] = GameObject.Find("Player4").GetComponent<Player>();
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
