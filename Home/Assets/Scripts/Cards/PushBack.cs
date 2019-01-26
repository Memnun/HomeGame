using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : BaseCard
{
    public int itemID = 15;
    public string longName = "Move Player Back";

    private int x = -3;

    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
    	if (target.targetable) {
			player.move(x);
			return true;
		} return false;
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
