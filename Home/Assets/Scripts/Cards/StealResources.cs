using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealResources : BaseCard
{
    public int itemID = 8;
    public string longName = "Steal Resources";

    private int x = 3;

    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
    	//
    	return false;
    }

    //function for using the card with two player targets
    public bool Activation (Player target1, Player target2) {
    	target2.gainResource(1,(0-x));
		target1.gainResource(1,x);
        return true;
    }

    //more abstract 2-target activator, for modifying non-player data
    public bool Activation (GameObject target1, GameObject target2) {
    	//
        return false;
    }
}
