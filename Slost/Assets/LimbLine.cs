using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbLine : MonoBehaviour {

    private LineRenderer limbLine;
    public Transform socket;

    public int lastIndex;

	// Use this for initialization
	void Start () {
        //socket = transform.parent;
        limbLine = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        limbLine.SetPosition(lastIndex, new Vector3(transform.position.x, transform.position.y, -1));
        limbLine.SetPosition(0, new Vector3(socket.position.x, socket.position.y, -1));
    }
}
