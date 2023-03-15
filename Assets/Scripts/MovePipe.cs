using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    public float speed;
    public float to_right;
    public float flip_face;
    public float up_to=0;
    private int direction=1;

    void Start() {
        if (to_right == 1) {
            direction = -1;
        }
    }

    void Update()
    {

        transform.position += Vector3.left * speed * Time.deltaTime * direction;
        transform.position += Vector3.up * up_to * Time.deltaTime;
    }
}
