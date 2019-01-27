using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraCont : MonoBehaviour
{
    public Globals globals;
    public GameObject MainCamera;
    public GameObject Player1POS, Player2POS, Player3POS, Player4POS;

    public Vector3 startingPos;
    public float speed = 3;
    public float lerpTimer;

    // Start is called before the first frame update
    void Start()
    {
        lerpTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.currentPlayer.name == "Player1")
        {
            MainCamera.transform.position = Vector3.Lerp(startingPos, Player1POS.transform.position, (Time.time-lerpTimer)*speed);
        }

        if (Globals.currentPlayer.name == "Player2")
        {

            MainCamera.transform.position = Vector3.Lerp(startingPos, Player2POS.transform.position, (Time.time-lerpTimer)*speed);
            
        }
    
        if (Globals.currentPlayer.name == "Player3")
        {

            MainCamera.transform.position = Vector3.Lerp(startingPos, Player3POS.transform.position, (Time.time-lerpTimer)*speed);
            
        }
    
        if (Globals.currentPlayer.name == "Player4")
        {

            MainCamera.transform.position = Vector3.Lerp(startingPos, Player4POS.transform.position, (Time.time-lerpTimer)*speed);
            
        }

    }

}
