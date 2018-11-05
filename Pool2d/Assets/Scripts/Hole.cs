using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // When a ball touches the hole it is destroyed
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Ball")
        {
            Destroy(Other.gameObject);
        }
        else if (Other.tag == "CueBall")
        {
            Other.transform.position = new Vector3(0, 0, 0);
        }
        
    }
}
