using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    bool shitted = false;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (MouseController.controller.endGame && collision.collider.CompareTag("Sloth")) {
            if (!MouseController.controller.dead && !shitted) {
                MouseController.controller.Shit();
                MouseController.controller.Win();
                shitted = true;
            }
            else {
                MouseController.controller.Shit();
            }
        }
    }
}
