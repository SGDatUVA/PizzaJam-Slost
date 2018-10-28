using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

    public float speedMultiplier;
    public float maxFallingVelocity;
    public float maxAngularVelocity;
    private float fallingVelocity;
    private float angularVelocity;
    private Vector2 downVector = new Vector2(0f, -1f);

    private void Start()
    {
        fallingVelocity = Random.Range(.7f, maxFallingVelocity);
        angularVelocity = Random.Range(-maxAngularVelocity, maxAngularVelocity);
    }

    // Update is called once per frame
    void Update () {
        GetComponent<Rigidbody2D>().velocity = downVector * fallingVelocity * speedMultiplier;
        GetComponent<Rigidbody2D>().angularVelocity = angularVelocity;
	}
}
