using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cue : MonoBehaviour
{
    public Vector3 force;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per update
    void FixedUpdate()
    {
        // Moves to indicate the current force
        force.z = -2.2f;
        force.y = 6.5f;
        force.x = Movement.force*(2f/3) - 10f;
        transform.position = force;
    }
}
