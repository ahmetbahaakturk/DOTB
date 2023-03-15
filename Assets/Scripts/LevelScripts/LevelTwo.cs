using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwo : MonoBehaviour
{
    public GameObject bird;
    Bird bird_script;
    RandomPipes pipe_creator_script;
    void Start()
    {
        bird_script = bird.GetComponent<Bird>();
        bird_script.score = 0;
        Time.timeScale = 0;
        GameObject pipe_creator = GameObject.Find("PipeCreator");
        pipe_creator_script = pipe_creator.GetComponent<RandomPipes>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird_script.is_free) {
            bird_script.game_paused = false;
            pipe_creator_script.limit = 10000;
        }
        int scene_index = SceneManager.GetActiveScene().buildIndex;
        if (scene_index == 3  && bird_script.game_paused == false){
            if (Input.anyKey) {
                Time.timeScale = 1;
            }

            if (bird_script.score == 12) {
            
                bird_script.score = 0;
                SceneManager.LoadScene(scene_index + 1, LoadSceneMode.Single);
            }
        }
    }
}
