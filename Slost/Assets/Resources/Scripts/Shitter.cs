using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shitter : MonoBehaviour {

    public static Shitter shitter;

    public GameObject shit;

    private void Start() {
        shitter = this;
    }

    public void Shit() {
        Instantiate(shit, transform.position, transform.rotation);
	}
}
