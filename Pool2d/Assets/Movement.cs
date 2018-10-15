using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    Vector3 mousePos;
    Vector3 dir;
    Vector3 displacement;
    Camera cam;
    public float speed = 100000f;
    public Vector2 maxVelocity = new Vector2(100000, 100000);
    public int moveSpeed = 1000;
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    public static float force = 0f;
    public float distance;
    public float dis;

    // Use this for initialization
    void Start () {
        cam = GameObject.FindObjectOfType<Camera>();
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        dir = mousePos - transform.position;
        dir = dir.normalized;

        displacement = mousePos - transform.position;
        displacement.z = 0;
        distance = displacement.magnitude;

        float forceX = 0f;
        float forceY = 0f;
        var absVelX = Mathf.Abs(body2D.velocity.x);
        if (absVelX < maxVelocity.x)
        {
            forceX = dir.x;
            forceY = dir.y;
            //transform.position = Vector3.MoveTowards(transform.position, mousePos, moveSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift))
            force -= 0.7f;
        else if (Input.GetKey(KeyCode.Space))
        {
            force += 0.7f;
        }
        if (force > 30)
            force = 0;
        dis = force;
        //Vector3 distance = (mousePos.transform.position - transform.position);
        if (Input.GetMouseButtonDown(0))
            body2D.AddForce(new Vector2(forceX*force, forceY*force), ForceMode2D.Impulse);

        //transform.position = mousePos;
    }
}
