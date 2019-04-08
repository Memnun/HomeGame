using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : ScriptableObject
{
	public List<BaseCard> cards;
    // Start is called before the first frame update
    public CardHandler()
    {
        cards = new List<BaseCard>();

        cards.Add( new BaseCard(1, "Stash of Berries"));
        cards.Add( new BaseCard(2, "Boost of Energy"));
        cards.Add( new BaseCard(3, "Shortcut"));
        cards.Add( new BaseCard(4, "Leap Forward"));
        cards.Add( new BaseCard(5, "Immunity"));
        cards.Add( new BaseCard(6, "Theft of Luck"));
        cards.Add( new BaseCard(7, "Big Eater"));
        cards.Add( new BaseCard(8, "Burn"));
        cards.Add( new BaseCard(9, "Frozen"));
        cards.Add( new BaseCard(10, "Shove Back"));
    }



    public bool PlayCard(int itemID, GameObject target2) {
    	switch (itemID) {
    		case 1:
    			return true;
    		case 2:
    			return true;
    		case 3:
    			return true;
    		case 4:
    			return true;
    		case 5:
    			return true;
    		case 6:
    			return false;
    		case 7:
    			return false;
    		case 8:
    			return false;
    		case 9:
    			return false;
    		case 10:
    			return false;
    		default:
    			return false;
    	}
    	return false;
    }

    public string GetCardName(int itemID) {
    	foreach (BaseCard card in cards) {
    		if (card.itemID == itemID) {
    			return card.longName;
    		}
    	}
    	return "";
    }
}
