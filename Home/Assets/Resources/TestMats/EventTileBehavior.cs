using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTileBehavior : MonoBehaviour
{

    public int isJumpedOn;

    // Start is called before the first frame update
    void Start()
    {
        isJumpedOn = 0;
        GetComponent<Renderer>().material = new Material (Resources.Load("TestMats/UnknownTile") as Material);
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumpedOn == 1) {
        	GetComponent<Renderer>().material = new Material (Resources.Load("TestMats/EventTile") as Material);
        	isJumpedOn = 2;
        }
    }
}
