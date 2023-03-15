using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congrats : MonoBehaviour
{
    public GameObject pause_menu;
    void Start() {
        pause_menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (! (pause_menu.activeSelf)) {
                pause_menu.SetActive(true);
            } else {
                pause_menu.SetActive(false);
            }
        }
    }
}
