using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
    public static Transform currentAttract;
    public static FootClick currentFoot;

    Camera main;

    FootClick[] footClicks;

	// Use this for initialization
	void Start () {
        main = Camera.main;
        footClicks = FindObjectsOfType<FootClick>();
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
            foreach (FootClick footClick in footClicks) {
                next = Vector2.Distance(pos, footClick.transform.position);
                if (next < shortestDist) {
                    shortestDist = next;
                    currentFoot = footClick;
                }
            }
            currentAttract = currentFoot.attractPoint;
            currentFoot.Click();
        }

        if (Input.GetMouseButtonUp(0)) {
            currentAttract = null;
            currentFoot.Unclick();
            currentFoot = null;
        }
	}
}
