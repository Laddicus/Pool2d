using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Point : NetworkBehaviour{

    Camera cam;

    Vector3 mousePosition;
    Vector3 ballPosition;
    Vector3 displacement;

    GameObject CueBall;
    float angle;

    // Use this for initialization
    void Start () {
        CueBall = GameObject.FindGameObjectWithTag("CueBall");
        cam = GameObject.FindObjectOfType<Camera>();
        Cursor.visible = false;
        CursorLockMode wantedMode = CursorLockMode.Confined;
    }

	// Update is called once per update
	void FixedUpdate () {
        // Follow ball
        transform.position = ballPosition;

        if (!CueBall.GetComponent<Movement>().isLocked)
        {
        // angle stuff to rotate the pointer towards the mouse
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        ballPosition = GameObject.FindGameObjectWithTag("CueBall").GetComponent<SpriteRenderer>().transform.position;

        displacement = mousePosition - ballPosition; // Since the pointer is at the same position as the ball this finds the pointers position relative to the mouse
        displacement.z = 0;

        angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
