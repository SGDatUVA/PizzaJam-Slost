using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    public static bool falling = false;
    static int gripNum = 0;
    static float fallTimer = 0;
    public float fallThreshold = 1f;

    static List<Claw> claws;

    private void Start() {
        claws = new List<Claw>(transform.parent.GetComponentsInChildren<Claw>());
    }

    // Update is called once per frame
    void Update () {
        if (falling) {
            fallTimer += Time.deltaTime;
        }
	}

    public static void RemoveGrip() {
        gripNum--;
        if (gripNum <= 1) {
            foreach (Claw claw in claws) {
                claw.Click();
            }
        }
        falling = (gripNum == 0);
        //Debug.Log(gripNum);

    }

    public static void AddGrip() {
        gripNum++;
        falling = false;
        fallTimer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("WHHOPS");
        if (collision.collider.CompareTag("Ground")) {
            if (fallTimer > fallThreshold) {
                Die();
            }
        }
    }

    void Die() {
        foreach (Claw claw in claws) {
            claw.Flail();
        }
    }
}
