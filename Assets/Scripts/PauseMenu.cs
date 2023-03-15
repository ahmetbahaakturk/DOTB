using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject[] objects;
    public GameObject bird_object;
    private Bird bird;

    void Start()
    {
        Time.timeScale = 0;
        Button[] buttons = FindObjectsOfType(typeof(Button)) as Button[];

        foreach (Button button in buttons) {
            button.onClick.AddListener(delegate{clicked(button);});
        }
    }

    void clicked(Button button) {
        if (button.name == "Exit") {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        try {
            bird = bird_object.GetComponent<Bird>();

            if (button.name == "PlayButton") {
                bird.game_paused = false;
                GameObject.Find("PauseMenu").SetActive(false);
                Time.timeScale = 1;
            }

            if (button.name == "PreviousLevel") {
                if (SceneManager.GetActiveScene().name != "egitimlevel 1" && SceneManager.GetActiveScene().name != "level1free") {
                    SceneManager.LoadScene(bird.last_scene_index - 1, LoadSceneMode.Single);
                }
            }

            if (button.name == "NextLevel") {
                if (SceneManager.GetActiveScene().name != "level4" && SceneManager.GetActiveScene().name != "level4free") {
                    SceneManager.LoadScene(bird.last_scene_index + 1, LoadSceneMode.Single);
                }

                if (SceneManager.GetActiveScene().name == "level4free") {
                    SceneManager.LoadScene("congrats", LoadSceneMode.Single);
                }
            }
        } catch {
            if (button.name == "PlayButton") {
                GameObject.Find("PauseMenu").SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
