using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class turnManager : NetworkBehaviour
{
    public int ready = 0;
    GameObject CueBall;
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    public Vector3 SumVector;
    public float SumForce;

    // Use this for initialization
    void Start()
    {
        CueBall = GameObject.FindGameObjectWithTag("CueBall");
        body2D = CueBall.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(ready);
        if (ready >= 2)
        {
            CmdShoot();
        }
    }
    public void addVectors(Vector3 vector)
    {
        SumVector += vector;
    }
    public void addForce(float force)
    {
        SumForce += force;
    }
    [Command]
    void CmdShoot()
    {
        body2D.AddForce(new Vector2(SumVector.x * SumForce, SumVector.y * SumForce), ForceMode2D.Impulse);
        
    }
}
