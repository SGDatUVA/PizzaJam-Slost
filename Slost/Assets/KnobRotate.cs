using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.rotation = Random.rotation;	
	}
}
