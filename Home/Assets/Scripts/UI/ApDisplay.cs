using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApDisplay : MonoBehaviour
{
	public Sprite Ap1, Ap2, Ap3, Ap4, Ap5, Ap6;
	public Image ApIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	switch (GameObject.Find(Globals.Instance.playerList[Globals.Instance.currentPlayer].name).GetComponent<Player>().actionPoints) {
    		case 1:
    			ApIcon.sprite = Ap1;
    			break;
    		case 2:
    			ApIcon.sprite = Ap2;
    			break;
			case 3:
    			ApIcon.sprite = Ap3;
    			break;
    		case 4:
    			ApIcon.sprite = Ap4;
    			break;
    		case 5:
    			ApIcon.sprite = Ap5;
    			break;
    		case 6:
    			ApIcon.sprite = Ap6;
    			break;
    	}
    }
}
