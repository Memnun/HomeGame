using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour
{
    int PlayerNum;
   	public Button TwoPlayer;
	public Button ThreePlayer;
	public Button FourPlayer;

    void Start()
    {
        TwoPlayer.onClick.AddListener(TwoPeople);
        ThreePlayer.onClick.AddListener(ThreePeople);
        FourPlayer.onClick.AddListener(FourPeople);

    }

    void TwoPeople()
    {
    	PlayerNum = 2;
    	Globals.Instance.players = PlayerNum;
    }
    
    void ThreePeople()
    {
    	PlayerNum = 3;
    	Globals.Instance.players = PlayerNum;
    }
    
    void FourPeople()
    {
    	PlayerNum = 4;
    	Globals.Instance.players = PlayerNum;
    }

}
