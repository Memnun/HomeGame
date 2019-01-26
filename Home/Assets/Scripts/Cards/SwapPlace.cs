using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlace : BaseCard
{
    public int itemID = 9;
    public string longName = "Exchange Places";

    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
		//
    	return false;
    }

    //function for using the card with two player targets
    public bool Activation (Player target1, Player target2) {
		if (target2.targetable) {
			int x = target1.space;
			target1.space = target2.space;
			target2.space = x;
		}
        return false;
    }

    //more abstract 2-target activator, for modifying non-player data
    public bool Activation (GameObject target1, GameObject target2) {
    	//
        return false;
    }
}
