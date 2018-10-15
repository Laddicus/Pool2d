using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cue : MonoBehaviour
{
    
    Camera cam;

    Vector3 mousePosition;
    Vector3 ballPosition;
    Vector3 displacement;
    Vector3 direction;
    Vector3 final;
    public Vector3 force;

    float distance;
    float angle;

    // Use this for initialization
    void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // angle stuff
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        
        ballPosition = GameObject.FindGameObjectWithTag("CueBall").GetComponent<SpriteRenderer>().transform.position;

        displacement = mousePosition - ballPosition;
        displacement.z = 0;
        distance = displacement.magnitude;

        final.z = 0;
        final.y = 6.5f;
        final.x = distance - 12f;
        //direction = displacement / distance;

        //angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle);

        // Follow ball
        force.z = 0;
        force.y = 6.5f;
        force.x = Movement.force*(2f/3) - 10f;
        transform.position = force;
    }
}
