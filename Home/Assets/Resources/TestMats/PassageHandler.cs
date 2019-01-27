using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageHandler : MonoBehaviour
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
        	GetComponent<Renderer>().material = new Material (Resources.Load("TestMats/SpookyTile") as Material);
        	isJumpedOn = 2;
        }
    }
}
