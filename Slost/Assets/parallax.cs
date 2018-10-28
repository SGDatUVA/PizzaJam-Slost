using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour {

    Camera main;
    float xOffset, yOffset;

	// Use this for initialization
	void Start () {
        main = Camera.main;
        xOffset = main.transform.position.x - transform.position.x;
        yOffset = main.transform.position.y - transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (main.transform.position.y > 0) {
            transform.position = new Vector3(main.transform.position.x-xOffset, main.transform.position.y-yOffset, transform.position.z);
        }
	}
}
