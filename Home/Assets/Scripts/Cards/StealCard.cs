using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealCard : BaseCard
{
    public int itemID = 16;
    public string longName = "Steal A Card";

    private int x = 0;

    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
    	//
		return false;
    }

    //function for using the card with two player targets
    public bool Activation (Player target1, Player target2) {
    	if (target2.targetable) {
			for (int i = 1; i<64; i++) {
				if (target2.inventory[i].y > 0) {
					target2.gainResource((int)target2.inventory[i].x,-1);
					target1.gainResource((int)target2.inventory[i].x,1);
					return true;
				}
			}
		} return false;
    }

    //more abstract 2-target activator, for modifying non-player data
    public bool Activation (GameObject target1, GameObject target2) {
    	//
        return false;
    }
}
