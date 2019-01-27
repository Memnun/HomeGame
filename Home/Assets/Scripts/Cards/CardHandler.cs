using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour
{
	public List<BaseCard> cards;
    // Start is called before the first frame update
    void Start()
    {
        cards = new List<BaseCard>();

        cards.Add( new BaseCard(2, "Gain Resources"));
        cards.Add( new BaseCard(3, "Instant AP"));
        cards.Add( new BaseCard(4, "Jump to Passage"));
        cards.Add( new BaseCard(5, "Hop Forward"));
        cards.Add( new BaseCard(6, "Protection from Hinderances"));
        cards.Add( new BaseCard(7, "Steal AP Capacity"));
        cards.Add( new BaseCard(8, "Steal Resources"));
        cards.Add( new BaseCard(9, "Exchange Places"));
        cards.Add( new BaseCard(14, "Gain 2 Cards"));
        cards.Add( new BaseCard(15, "Move Player Back"));
        cards.Add( new BaseCard(16, "Steal A Card"));
        cards.Add( new BaseCard(17, "Burn A Card"));
        cards.Add( new BaseCard(18, "Jump Across Ring"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void motionlessWalk (Player player) {
		if (player.space == 48) {
			player.jump(1);
		} else if (player.space == 82) {
			player.jump(51);
		} else if (player.space == 100) {
			player.jump(85);
		} else {
			player.move(1);
		}
	}

    public bool PlayCard(int itemID, GameObject target1, GameObject target2) {
    	switch (itemID) {
    		case 2:
    			target1.GetComponent<Player>().gainResource(1,5);
    			return true;
    		case 3:
    			target1.GetComponent<Player>().actionPoints +=1;
    			return true;
    		case 4:
    			if (target1.GetComponent<Player>().space <= 48) {
    				target1.GetComponent<Player>().jump(48);
    			} else if (target1.GetComponent<Player>().space <= 82) {
    				target1.GetComponent<Player>().jump(82);
    			} else {
    				target1.GetComponent<Player>().jump(100);
    			}
    			return true;
    		case 5:
    			target1.GetComponent<PlayerControl>().moveForward(1);
    			target1.GetComponent<PlayerControl>().moveForward(1);
    			target1.GetComponent<PlayerControl>().moveForward(1);
    			return true;
    		case 6:
    			target1.GetComponent<Player>().targetable = false;
    			return true;
    		case 7:
    			if (target2.GetComponent<Player>().targetable) {
    				target2.GetComponent<Player>().changeApMax(-1);
    				target1.GetComponent<Player>().changeApMax(1);
    				return true;
    			}
    			return false;
    		case 8:
    			if (target2.GetComponent<Player>().targetable) {
    				target2.GetComponent<Player>().gainResource(1,-3);
    				target1.GetComponent<Player>().gainResource(1,3);
    				return true;
    			}
    			return false;
    		case 9:
    			if (target2.GetComponent<Player>().targetable) {
    				int x = target1.GetComponent<Player>().space;
    				target1.GetComponent<Player>().space = target2.GetComponent<Player>().space;
    				target2.GetComponent<Player>().space = x;
    				return true;
    			}
    			return false;
    		case 14:
    			target1.GetComponent<Player>().gainResource(Random.Range(2,19),1);
    			target1.GetComponent<Player>().gainResource(Random.Range(2,19),1);
    			return true;
    		case 15:
    			if (target2.GetComponent<Player>().targetable) {
    				target2.GetComponent<Player>().move(-3);
    				return true;
    			}
    			return false;
    		case 16:
    			if (target2.GetComponent<Player>().targetable) {
    				foreach (Vector2 item in target2.GetComponent<Player>().inventory) {
    					if (item.x > 1 && item.y > 0) {
    						target2.GetComponent<Player>().gainResource((int)item.x,-1);
    						target1.GetComponent<Player>().gainResource((int)item.x,1);
    						return true;
    					}
    				}
    			}
    			return false;
    		case 17:
    			if (target2.GetComponent<Player>().targetable) {
    				foreach (Vector2 item in target2.GetComponent<Player>().inventory) {
    					if (item.x > 1 && item.y > 0) {
    						target2.GetComponent<Player>().gainResource((int)item.x,-1);
    						return true;
    					}
    				}
    			}
    			return false;
    		case 18:
	    		if (target1.GetComponent<Player>().space <= 48) {
	    			for (int i = 0; i<23; i++) {
	    				motionlessWalk(target1.GetComponent<Player>());
	    			}
	    			target1.GetComponent<PlayerControl>().moveForward(1);
    			} else if (target1.GetComponent<Player>().space <= 82) {
    				for (int i = 0; i<23; i++) {
	    				motionlessWalk(target1.GetComponent<Player>());
	    			}
	    			target1.GetComponent<PlayerControl>().moveForward(1);
    			} else {
    				for (int i = 0; i<23; i++) {
	    				motionlessWalk(target1.GetComponent<Player>());
	    			}
	    			target1.GetComponent<PlayerControl>().moveForward(1);
    			}
    			return true;
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
