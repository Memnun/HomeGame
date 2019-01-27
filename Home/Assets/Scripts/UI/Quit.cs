using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
	 public float speed;
	 private Vector2 Temp;
     public float XMax;
     public float YMax;

    // Update is called once per frame
    void Update()
    {
    	Temp = transform.localScale;
    	Temp.x += Time.deltaTime * speed;
    	Temp.y += Time.deltaTime * speed;

    	transform.localScale = Temp;

    	if(transform.localScale.x >= XMax && transform.localScale.y >= YMax)
    		{
    			speed = 0;
    		} 
        
    }
}
