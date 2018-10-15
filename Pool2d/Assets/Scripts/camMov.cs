using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMov : MonoBehaviour {
    Vector3 ballPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        ballPosition = GameObject.FindGameObjectWithTag("CueBall").GetComponent<SpriteRenderer>().transform.position;
        ballPosition.z = -10f;
        transform.position = ballPosition;
    }
}
