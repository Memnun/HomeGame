using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceXSpaces : BaseCard
{
    public int itemID = 5;
    public string longName = "Hop Forward";

    private int x = 2;

    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
    	for (int i = 0; i < x; i++) {
	    	target.GetComponent<PlayerControl>().moveForward(1);
	    }
	    return true;
    }

    //function for using the card with two player targets
    public bool Activation (Player target1, Player target2) {
    	//
        return false;
    }

    //more abstract 2-target activator, for modifying non-player data
    public bool Activation (GameObject target1, GameObject target2) {
    	//
        return false;
    }
}
