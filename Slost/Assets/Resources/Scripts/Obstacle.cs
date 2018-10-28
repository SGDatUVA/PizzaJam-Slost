using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ObstEvent(); 

public class Obstacle : MonoBehaviour {

    public ObstEvent hitEvent;
    Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Sloth") || collision.collider.CompareTag("Claw")) {
            if (hitEvent != null) {
                hitEvent();
            }
            rb.gravityScale = 1;
            rb.AddForce(collision.contacts[0].normal * 500);
        }
    }
}
