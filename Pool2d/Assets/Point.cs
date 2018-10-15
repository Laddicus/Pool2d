using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

    Camera cam;

    Vector3 mousePosition;
    Vector3 ballPosition;
    Vector3 displacement;
    Vector3 direction;

    float distance;
    float angle;

    // Use this for initialization
    void Start () {
        cam = GameObject.FindObjectOfType<Camera>();
        Cursor.visible = false;
        CursorLockMode wantedMode = CursorLockMode.Confined;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // angle stuff
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        ballPosition = GameObject.FindGameObjectWithTag("CueBall").GetComponent<SpriteRenderer>().transform.position;

        displacement = mousePosition - ballPosition;
        displacement.z = 0;
        distance = displacement.magnitude;
        direction = displacement / distance;

        angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Follow ball
        transform.position = ballPosition;
    }
}
