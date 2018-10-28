using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void HitEvent(float timer);

public class ChildCollider : MonoBehaviour {

    public HitEvent hitEvent;


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Obstacle")) {
            if (hitEvent != null) {
                hitEvent(2);
            }
        }
    }

}
