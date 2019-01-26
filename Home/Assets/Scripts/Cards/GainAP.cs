using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainAP : BaseCard
{
    public int itemID = 3;
    public string longName = "Instant AP";

    private int x = 1;

    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
    	target.actionPoints += x;
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
