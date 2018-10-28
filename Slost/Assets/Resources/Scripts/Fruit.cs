using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    FixedJoint2D joint;
    bool grabbed = false;
    bool gettinEt = false;
    public GameObject fruitImage;

    float progress = 1f;
    float scaleSpeed = 1f;

	// Use this for initialization
	void Start () {
        joint = GetComponent<FixedJoint2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Claw")) {
            if (!grabbed) {
                joint.connectedBody = collision.collider.GetComponent<Rigidbody2D>();
                grabbed = true;
            }
        }
        else if (collision.collider.GetComponent<Head>()) {
            if (!gettinEt) {
                joint.connectedBody = collision.collider.GetComponent<Rigidbody2D>();
                gettinEt = true;
                grabbed = true;
                StartCoroutine(Gulp());
            }
        }
    }

    IEnumerator Gulp() {
        while (progress > 0) {
            progress -= scaleSpeed * Time.deltaTime;
            fruitImage.transform.localScale = new Vector3(progress, progress, 1);
            yield return null;
        }
        Destroy(gameObject);
        MouseController.controller.TriggerEnd();
    }
}
