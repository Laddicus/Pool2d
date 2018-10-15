using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    Vector3 mousePos;
    Vector3 dir;
    Camera cam;
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    public static float force = 0f; // Should do this a different way
    float forceX = 0f;
    float forceY = 0f;

    // Use this for initialization
    void Start () {
        cam = GameObject.FindObjectOfType<Camera>();
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
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
            forceX = dir.x;
            forceY = dir.y;
            body2D.AddForce(new Vector2(forceX*force, forceY*force), ForceMode2D.Impulse);
        }
    }
}
