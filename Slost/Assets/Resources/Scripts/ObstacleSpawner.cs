using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    float timer;
    float maxTime = 5f;

    public float minX, maxX;

    public GameObject obstacle;

    private void Start() {
        timer = maxTime;
    }

    // Update is called once per frame
    void Update () {
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
        else {
            timer = maxTime;
            Instantiate(obstacle, new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.y), Quaternion.identity);
        }
    }
}
