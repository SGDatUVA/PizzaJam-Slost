﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCollider : MonoBehaviour {

    float stunTimer = 0;
    float maxStunTimer = 2f;
    float stunThreshold = 0.5f;
    bool stunned = false;

    Claw claw;

	// Use this for initialization
	void Start () {

        foreach (ChildCollider collider in GetComponentsInChildren<ChildCollider>()) {
            collider.hitEvent += Collide;
        }

        claw = GetComponentInChildren<Claw>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (stunTimer > 0) {
            stunTimer += Time.deltaTime;
        }
        else if (stunned == true) {
            claw.Unstun();
            stunned = false;
        }
	}

    private void Collide() {
        if (stunTimer < stunThreshold) {
            claw.Stun();
            stunTimer = maxStunTimer;
            stunned = true;
        }
    }
}
