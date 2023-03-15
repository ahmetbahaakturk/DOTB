using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelZero : MonoBehaviour
{
    public GameObject bird;
    Bird bird_script;
    void Start()
    {
        bird_script = bird.GetComponent<Bird>();
    }

    void Update()
    {
        int scene_index = SceneManager.GetActiveScene().buildIndex;
        if (scene_index == 1 && GameObject.Find("PauseMenu").activeSelf == false){
            if (Input.anyKey) {
                Time.timeScale = 1;
            }
        }
    }
}
