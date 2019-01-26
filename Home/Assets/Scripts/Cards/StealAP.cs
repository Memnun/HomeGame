using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealAP : BaseCard
{
    public int itemID = 7;
    public string longName = "Steal AP capacity";

    private int x = 1;

    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
    	//
    	return false;
    }

    //function for using the card with two player targets
    public bool Activation (Player target1, Player target2) {
		if (target2.targetable) {
			target2.changeApMax(-1);
			target1.changeApMax(1);
			return true;
		} return false;
    }

    //more abstract 2-target activator, for modifying non-player data
    public bool Activation (GameObject target1, GameObject target2) {
    	//
        return false;
    }
}
