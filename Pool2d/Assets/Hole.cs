﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Ball")
        {
            Debug.Log("bwa");
            Destroy(Other.gameObject);
        }
        
    }
}
