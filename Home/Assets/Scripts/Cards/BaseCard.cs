using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCard : MonoBehaviour
{
    
    public int itemID;
    public string longName;

    public BaseCard (int id, string name){
        itemID = id;
        longName = name;
    }
    
}
