using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {

    public FixedJoint2D grip;
    public TreeBit gripPoint;

    public Transform attractPoint;
    SpringJoint2D spring;
    public bool stunned = false;

    bool start = true;

    public bool gripped = false;

    public bool falling = false;

    ParentCollider manager;

    private void Start() {
        grip.enabled = false;
    }


    private void Init() {
        spring = GetComponent<SpringJoint2D>();
        manager = GetComponentInParent<ParentCollider>();
        Unclick();
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
            gripped = false;
            grip.connectedBody = null;
            grip.enabled = false;
            spring.enabled = true;
            MouseController.controller.RemoveGrip();
        }
    }

    public void Unclick() {
        if (gripPoint) {
            gripped = true;
            grip.enabled = true;
            grip.connectedBody = gripPoint.GetComponent<Rigidbody2D>();
            grip.connectedAnchor = transform.position;
            spring.enabled = false;
            MouseController.controller.AddGrip();
        }
    }

    public void Stun(float timer) {
        manager.Collide(timer);
    }

    public void Stun() {
        Click();
        spring.enabled = false;
        stunned = true;
    }

    public void Unstun() {
        spring.enabled = true;
        stunned = false;
    }
}
