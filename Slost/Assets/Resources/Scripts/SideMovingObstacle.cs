using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovingObstacle : MonoBehaviour {

    public float speedMultiplier;
    public float movingVelocity;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * movingVelocity * speedMultiplier;
	}
}
