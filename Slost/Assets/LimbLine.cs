using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbLine : MonoBehaviour {

    private LineRenderer limbLine;
    public Transform socket;
    private Rigidbody2D body;

    private Vector3 newLocation;
    private Vector3 circleCenter;
    private float circleRadius;

    public int lastIndex;

	// Use this for initialization
	void Start () {
        //socket = transform.parent;
        limbLine = GetComponent<LineRenderer>();
        circleCenter = transform.parent.position;
        circleRadius = 2f;
        body = GetComponent<Rigidbody2D>();
        //transform.position = circleCenter;
        newLocation = transform.position;
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 0));
    }
	
	// Update is called once per frame
	void Update () {
        limbLine.SetPosition(lastIndex, transform.position);
        limbLine.SetPosition(0, socket.position);
    }
}
