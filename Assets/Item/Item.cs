using UnityEngine;
using System.Collections;
using System;

public class Item : MonoBehaviour {

    int uses;
    float coolDown;
    float coolDownCounter;

	// Use this for initialization
	void Start () {
        coolDownCounter = coolDown;
	}

    public void use()
    {
        if (uses > 0 && coolDownCounter == 0)
        {
            Console.WriteLine("Item Used");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(coolDownCounter > 0)
        {
            coolDownCounter -= Time.deltaTime;
        }
	}
}
