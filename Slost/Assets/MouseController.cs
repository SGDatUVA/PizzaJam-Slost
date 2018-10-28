using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
    public static Transform currentAttract;
    public static Claw currentClaw;
    public static int gripNum = 0;

    public static bool living = true;

    Camera main;

    static List<Claw> claws;

	// Use this for initialization
	void Start () {
        main = Camera.main;
        claws = new List<Claw>(FindObjectsOfType<Claw>());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && currentAttract && currentClaw) {
            currentAttract.transform.position = main.ScreenToWorldPoint((Vector2)Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(0)) {
            currentClaw = null;
            Vector2 pos = main.ScreenToWorldPoint((Vector2)Input.mousePosition);
            float shortestDist = float.MaxValue;
            float next;
            foreach (Claw claw in claws) {
                if (!claw.stunned) {
                    next = Vector2.Distance(pos, claw.transform.position);
                    if (next < shortestDist) {
                        shortestDist = next;
                        currentClaw = claw;
                    }
                }
            }
            if (currentClaw) {
                currentAttract = currentClaw.attractPoint;
                currentClaw.Click();
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            if (currentClaw) {
                currentAttract = null;
                currentClaw.Unclick();
                currentClaw = null;
            }
        }
	}

    public static void RemoveGrip() {
        gripNum--;
        if (gripNum <= 1) {
            foreach (Claw claw in claws) {
                claw.Stun();
            }
        }
    }

    public static void AddGrip() {
        gripNum++;
    }
}
