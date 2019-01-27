using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
	public Player player;
	public Text ActionPoints;

    void Update()
    {
        ActionPoints.text = "Action Points" + player.actionPoints;  
    }
}
