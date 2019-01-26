using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCard : MonoBehaviour
{
    
    public int itemID;
    public string longName;

    //the function to call when a player uses this particular card; target single player
    public bool Activation (Player target) {
    	//
        return false;
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
