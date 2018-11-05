using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class cue : NetworkBehaviour
{
    public Vector3 force;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per update
    void FixedUpdate()
    {
        //if (isLocalPlayer)
        {
        // Moves to indicate the current force
        force.z = -2.2f;
        force.y = 6.5f;
        force.x = Movement.force*(2f/3) - 10f;
        transform.position = force;
        }
    }
}
