using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {

    public FixedJoint2D grip;
    public TreeBit gripPoint;

    public Transform attractPoint;
    SpringJoint2D spring;


    private void Start() {
        grip.connectedBody = gripPoint.GetComponent<Rigidbody2D>();
        spring = GetComponent<SpringJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("TreeBit")) {
            gripPoint = collider.GetComponent<TreeBit>();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("TreeBit")) {
            gripPoint = null;
        }
    }

    public void Click() {
        if (grip.isActiveAndEnabled) {
            grip.connectedBody = null;
            grip.enabled = false;
            spring.enabled = true;
        }
    }

    public void Unclick() {
        if (gripPoint) {
            grip.enabled = true;
            grip.connectedBody = gripPoint.GetComponent<Rigidbody2D>();
            grip.connectedAnchor = transform.position;
            spring.enabled = false;
        }
    }
}
