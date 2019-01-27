using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPort : MonoBehaviour
{
	public Sprite Ch1, Ch2, Ch3, Ch4;
	public Image ChrIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	switch (Globals.currentPlayerNumber) {
    		case 1:
    			ChrIcon.sprite = Ch1;
    			break;
    		case 2:
    			ChrIcon.sprite = Ch2;
    			break;
			case 3:
    			ChrIcon.sprite = Ch3;
    			break;
    		case 4:
    			ChrIcon.sprite = Ch4;
    			break;
    	}
    }
}