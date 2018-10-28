using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour {

    public static RestartManager r;

	// Use this for initialization
	void Awake () {
        if (r) {
            Destroy(r);
        }
        else {
            r = this;
            DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(0);
        }
	}

    public void Credits() {
        StartCoroutine(fade());
    }

    IEnumerator fade() {
        ShitTimer.timer.Fade();
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(1);
    }
}
