using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShitTimer : MonoBehaviour {

    public static ShitTimer timer;

    public Slider slider;
    public bool start = false;

    float progress;
    float maxProgress = 60f;

    public Image fadeBox;

    private void Start() {
        progress = maxProgress;
        timer = this;
        slider = GetComponent<Slider>();
        gameObject.SetActive(false);
    }

    private void Update() {
        if (start) {
            progress -= Time.deltaTime;
            slider.value = Mathf.Lerp(0, 1, progress/maxProgress);

            if (progress <= 0) {
                MouseController.controller.Shit();
                MouseController.controller.Die();

            }
        }
    }

    public void StopTimer() {
        start = false;
        gameObject.SetActive(false);
    }

    public void StartTimer() {
        start = true;
        gameObject.SetActive(true);
    }

    public void Fade() {
        StartCoroutine(fade());
    }

    IEnumerator fade() {
        while (fadeBox.color != Color.white) {
            fadeBox.color = Color.Lerp(fadeBox.color, Color.white, Time.deltaTime * 0.5f);
            yield return null;
        }
    }
}
