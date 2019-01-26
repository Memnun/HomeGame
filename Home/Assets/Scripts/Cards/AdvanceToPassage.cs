using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceToPassage : MonoBehaviour
{
    public int itemID = 4;
    public string longName = "Jump to Passage";

    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
    	if (target.space <= 48) {
    		target.jump(48);
    	} else if (target.space <= 82) {
    		target.jump(82);
    	} else {
    		target.jump(100);
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
