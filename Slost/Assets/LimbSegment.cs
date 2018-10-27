using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbSegment : MonoBehaviour {

    public LineRenderer limbLine;
    public int index;
	
	// Update is called once per frame
	void Update () {
        limbLine.SetPosition(index, new Vector3(transform.position.x, transform.position.y, -1));
	}
}
