using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBit : MonoBehaviour {

    float maxHealth = 200f;
    float health;
    SpriteRenderer sprite;
    Transform image;
    Vector2 defaultPos;
    Color topColor;

	// Use this for initialization
	void Start () {
        sprite = GetComponentInChildren<SpriteRenderer>();
        image = sprite.transform;
        defaultPos = image.position;
        topColor = sprite.color;
        health = maxHealth;
	}


    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.CompareTag("Claw")) {
            Claw gripper = collider.GetComponent<Claw>();
            if (gripper.gripped) {
                health -= Time.deltaTime * 5;
                sprite.color = Color.Lerp(Color.black, topColor, health / maxHealth);
                Jitter();

                if (health <= 0) {
                    gripper.Stun(0.5f);
                    Destroy(gameObject);
                }
            }
        }
    }

    void Jitter() {
        image.position = defaultPos + (Random.insideUnitCircle * 0.1f * (1f-health/maxHealth));
    }
}
