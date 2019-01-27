using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraCont : MonoBehaviour
{
    public Globals globals;
    public Camera Player1Cam;
    public Camera Player2Cam;
    public Camera Player3Cam;
    public Camera Player4Cam;
    public Image Player1Icon, Player2Icon, Player3Icon, Player4Icon;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.currentPlayer.name == "Player1")
        {

            Player1Icon.gameObject.SetActive(true);
            Player2Icon.gameObject.SetActive(false);
            Player3Icon.gameObject.SetActive(false);
            Player4Icon.gameObject.SetActive(false);

            Player1Cam.gameObject.SetActive(true);
            Player2Cam.gameObject.SetActive(false);
            Player3Cam.gameObject.SetActive(false);
            Player4Cam.gameObject.SetActive(false);
        }

        if (Globals.currentPlayer.name == "Player2")
        {
            Debug.Log("p2 validates");
            Player1Icon.gameObject.SetActive(false);
            Player2Icon.gameObject.SetActive(true);
            Player3Icon.gameObject.SetActive(false);
            Player4Icon.gameObject.SetActive(false);


            Player1Cam.gameObject.SetActive(false);
            Player2Cam.gameObject.SetActive(true);
            Player3Cam.gameObject.SetActive(false);
            Player4Cam.gameObject.SetActive(false);
        } else {Debug.Log("p2 doesnt validate");}
    
        if (Globals.currentPlayer.name == "Player3")
        {
            Player1Icon.gameObject.SetActive(false);
            Player2Icon.gameObject.SetActive(false);
            Player3Icon.gameObject.SetActive(true);
            Player4Icon.gameObject.SetActive(false);


            Player1Cam.gameObject.SetActive(false);
            Player2Cam.gameObject.SetActive(false);
            Player3Cam.gameObject.SetActive(true);
            Player4Cam.gameObject.SetActive(false);
        }
    
        if (Globals.currentPlayer.name == "Player4")
        {
            Player1Icon.gameObject.SetActive(false);
            Player2Icon.gameObject.SetActive(false);
            Player3Icon.gameObject.SetActive(false);
            Player4Icon.gameObject.SetActive(true);


            Player1Cam.gameObject.SetActive(false);
            Player2Cam.gameObject.SetActive(false);
            Player3Cam.gameObject.SetActive(false);
            Player4Cam.gameObject.SetActive(true);
        }
    }
}
