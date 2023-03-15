using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Bird : MonoBehaviour
{
    public float jumping_value;
    public float score = 0;
    public int last_scene_index;
    public bool game_paused = false;
    public bool is_free = false;
    Rigidbody2D rb;
    AudioSource audio_source;
    public Text score_table;
    public GameObject pause_menu;
    public GameObject[] InfoMenus;
    public int click_counter = 0;

    void Start()
    {
        pause_menu.SetActive(false);
        last_scene_index = SceneManager.GetActiveScene().buildIndex;
        this.score = 0;
        audio_source = this.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (! (pause_menu.activeSelf) && Input.anyKey) {
            Time.timeScale = 1;
            Destroy(GameObject.Find("Menu"));

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                rb.velocity = Vector2.up * jumping_value;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (! (SceneManager.sceneCount > 1) && pause_menu.activeSelf == false) {
                Time.timeScale = 0;
                game_paused = true;
                pause_menu.SetActive(true);
            } else if (pause_menu.activeSelf) {
                game_paused = false;
                pause_menu.SetActive(false);
            }
        }
        score_table.text = this.score.ToString();
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space)){
            audio_source.Play();
        }
    }

    void GameOver(){
        Time.timeScale = 0;
        Destroy(audio_source);

        AudioListener[] allAudioListeners = FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
        foreach( AudioListener audioL in allAudioListeners) {
            Destroy(audioL);
        }

        Destroy(GameObject.Find("EventSystem"));

        SceneManager.LoadScene(6, LoadSceneMode.Additive);
    }

    private void OnCollisionEnter2D(Collision2D touch) {
        if (touch.gameObject.tag == "pipe" || touch.gameObject.tag == "base") {
            GameOver();
        }

        if (touch.gameObject.tag == "finish_line") {
            int scene_index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene_index + 1, LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D touch) {
        if (touch.gameObject.tag == "seed") {
            transform.localScale += new Vector3(1, 1, 0);
            Destroy(touch.gameObject);
            score_table.gameObject.SetActive(true);
            score_table.text = this.score.ToString();
        }

        if (touch.gameObject.tag  == "bullet" || touch.gameObject.tag == "fire_ball_E") {
            GameOver();
        }

        if (touch.gameObject.tag == "score_point") {
            this.score += 1;
        }
    }
}
