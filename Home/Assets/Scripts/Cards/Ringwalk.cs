using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ringwalk : BaseCard
{
    public int itemID = 18;
    public string longName = "Jump Around Ring";

    private int x = 0;
	
	private void foo () {
		if (player.space == 48) {
			player.jump(1);
		} else if (player.space == 82) {
			player.jump(51);
		} else if (player.space == 100) {
			player.jump(85);
		} else {
			player.move(distance);
		}
	}
	
    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
		if (target.space <= 48) {
    		for (int i = 0; i<7; i++) {
				foo();
			}
			target.GetComponent<PlayerControl>().moveForward(1);
    	} else if (target.space <= 82) {
    		for (int i = 0; i<15; i++) {
				foo();
			}
			target.GetComponent<PlayerControl>().moveForward(1);
    	} else {
    		for (int i = 0; i<23; i++) {
				foo();
			}
			target.GetComponent<PlayerControl>().moveForward(1);
    	}
        return true;
    }

    //function for using the card with two player targets
    public bool Activation (Player target1, Player target2) {
    	return false;
    }

    //more abstract 2-target activator, for modifying non-player data
    public bool Activation (GameObject target1, GameObject target2) {
    	//
        return false;
    }
}
