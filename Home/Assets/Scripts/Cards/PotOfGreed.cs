using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotOfGreed : BaseCard
{
    public int itemID = 14;
    public string longName = "Gain 2 Cards";
	
	public int x = 18;//number of cards

    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
			target.gainResource(Random.Range(2,x+1),1);
			target.gainResource(Random.Range(2,x+1),1);
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
