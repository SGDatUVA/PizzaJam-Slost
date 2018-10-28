using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
    public static MouseController controller;

    public Transform currentAttract;
    public Claw currentClaw;
    public int gripNum = 0;

    public bool living = true;

    Camera main;

    static List<Claw> claws;

    public bool stunned = false;

    public bool endGame = false;

    public bool dead = false;

	// Use this for initialization
	void Start () {
        controller = this;
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

        if (Input.GetMouseButtonUp(0) && !stunned) {
            if (currentClaw) {
                currentAttract = null;
                currentClaw.Unclick();
                currentClaw = null;
            }
        }
	}

    public void RemoveGrip() {
        gripNum--;
        if (gripNum <= 1 && !stunned) {
            stunned = true;
            StartCoroutine(Stun());
        }
    }

    public void AddGrip() {
        gripNum++;
    }

    IEnumerator Stun() {
        foreach (Claw claw in claws) {
            claw.Stun();
        }
        yield return new WaitForSeconds(1f);

        foreach (Claw claw in claws) {
            claw.Unstun();
        }
        stunned = false;
    }

    public void Shit() {
        Shitter.shitter.Shit();
    }

    public void Die() {
        foreach (Claw claw in claws) {
            claw.Stun();
        }

        GetComponent<AudioSource>().Play();
        dead = true;
        ShitTimer.timer.StopTimer();
    }

    public void TriggerEnd() {
        endGame = true;
        ShitTimer.timer.StartTimer();
    }

    public void Win() {
        ShitTimer.timer.StopTimer();
        RestartManager.r.Credits();
    }
}
