using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendFromHinderance : BaseCard
{
    public int itemID = 6;
    public string longName = "Protection from Hinderances";

    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
    	target.targetable = false;
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
