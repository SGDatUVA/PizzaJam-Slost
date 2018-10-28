using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {

    public FixedJoint2D grip;
    public TreeBit gripPoint;

    public Transform attractPoint;
    SpringJoint2D spring;

    bool start = true;

    private void Start() {
        grip.enabled = false;
    }


    private void Init() {
        grip.connectedBody = gripPoint.GetComponent<Rigidbody2D>();
        spring = GetComponent<SpringJoint2D>();
        grip.enabled = true;
        Body.AddGrip();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("TreeBit")) {
            gripPoint = collider.GetComponent<TreeBit>();
            if (start) {
                Init();
                start = false;
            }
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
            Body.RemoveGrip();
        }
    }

    public void Unclick() {
        if (gripPoint) {
            grip.enabled = true;
            grip.connectedBody = gripPoint.GetComponent<Rigidbody2D>();
            grip.connectedAnchor = transform.position;
            spring.enabled = false;
            Body.AddGrip();
        }
    }

    public void Flail() {
        transform.Translate(Vector3.up);
    }
}
