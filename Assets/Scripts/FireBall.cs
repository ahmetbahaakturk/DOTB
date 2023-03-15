using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    void Start()
    {
        Rigidbody2D fireBall_rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D touch) {
        if (touch.gameObject.tag == "target" ||  (touch.gameObject.tag == "seed" && this.gameObject.tag == "fireball")) {
            Destroy(touch.gameObject);
            Destroy(this.gameObject);
        }
        if (touch.gameObject.tag == "base") {
            Destroy(this.gameObject);
        }
        if (touch.gameObject.tag == "fire_ball_E") {
            Destroy(touch.gameObject);
        }
    }
}
