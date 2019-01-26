using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTileEvent : MonoBehaviour
{
    public int eventID;

    //the function to call when a player triggers this event; target single player
    public bool Activation (Player target) {
    	//
        return false;
    }

    //function for triggering the event with two player targets
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
