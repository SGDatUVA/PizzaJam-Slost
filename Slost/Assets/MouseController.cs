using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
    public static Transform currentAttract;
    public static Claw currentClaw;

    Camera main;

    Claw[] claws;

	// Use this for initialization
	void Start () {
        main = Camera.main;
        claws = FindObjectsOfType<Claw>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && currentAttract) {
            currentAttract.transform.position = main.ScreenToWorldPoint((Vector2)Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(0)) {
            Vector2 pos = main.ScreenToWorldPoint((Vector2)Input.mousePosition);
            float shortestDist = float.MaxValue;
            float next;
            foreach (Claw claw in claws) {
                next = Vector2.Distance(pos, claw.transform.position);
                if (next < shortestDist) {
                    shortestDist = next;
                    currentClaw = claw;
                }
            }
            currentAttract = currentClaw.attractPoint;
            currentClaw.Click();
        }

        if (Input.GetMouseButtonUp(0)) {
            currentAttract = null;
            currentClaw.Unclick();
            currentClaw = null;
        }
	}
}
