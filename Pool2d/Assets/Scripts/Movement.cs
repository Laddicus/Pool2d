using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour{
    Vector3 mousePos;
    Vector3 dir;
    Camera cam;
    public GameObject GameController;
    turnManager referenceScript;
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    public static float force = 0f; // Should do this a different way
    private Func<turnManager> thing;
    public bool isLocked = false;
    float forceX = 0f;
    float forceY = 0f;
    public int test = 0;

    // Use this for initialization
    void Start () {
        cam = GameObject.FindObjectOfType<Camera>();
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        GameController = GameObject.FindGameObjectWithTag("GameController");
        referenceScript = GameController.GetComponent<turnManager>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (referenceScript.ready >= 2)
        {
            //CmdCueMove();
        }

        // Creates a unit vector pointing to the cursor
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        dir = mousePos - transform.position;
        dir = dir.normalized;
        
        // Decrement force
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift))
            force -= 0.7f;
        else if (Input.GetKey(KeyCode.Space)) // Increment force
            force += 0.7f;

        if (force > 30) // Wraparound
            force = 0;
        
        if (Input.GetMouseButtonDown(0)) // Launch ball on click
        {
            CmdCueMove();
            if (isLocked)
            {

                referenceScript.ready--;
                isLocked = false;
            }
            else
            {
                forceX = dir.x;
                forceY = dir.y;
                referenceScript.addVectors(new Vector3(forceX * force, forceY * force));
                referenceScript.ready++;
                isLocked = true;
            }
        }
        //GameController.GetComponent<turnManager.SubReady()>

    }

    [Command]
    void CmdCueMove()
    {

    }
}
