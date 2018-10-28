using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.GetComponent<Body>()) {
            Debug.Log("AAAAAAA");
            if (MouseController.controller.gripNum <= 0) {
                Debug.Log("DEATH!!!!");
                MouseController.controller.Die();
            }
        }
        else if (collider.CompareTag("Obstacle")) {
            Destroy(collider.gameObject, 4f);
        }
    }
}
